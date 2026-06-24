using ArchaeologicalSiteManagement.Commands;
using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ArchaeologicalSiteManagement.ViewModels
{
	public class MainViewModel : INotifyPropertyChanged
    {
		ISiteRepository _siteRepository;
		IExcavationRepository _excRepository;
		IPersistenceService _persistenceService;
		Stack<ICommand> _undoStack;
		Stack<ICommand> _redoStack;

        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ArchaeologicalSite> _sites;
        private ObservableCollection<ExcavationRecord> _records;

        public ObservableCollection<ArchaeologicalSite> Sites
		{
			get { return _sites; }
			set { _sites = value; OnPropertyChanged(nameof(Sites)); }
		}

		public ObservableCollection<ExcavationRecord> Records
		{
            get { return _records; }
            set { _records = value; OnPropertyChanged(nameof(Records)); }
        }

        public MainViewModel(ISiteRepository siteRepository, IExcavationRepository excRepository, IPersistenceService persistenceService)
        {
            _siteRepository = siteRepository;
            _excRepository = excRepository;
            _persistenceService = persistenceService;
            _undoStack = new Stack<ICommand>();
            _redoStack = new Stack<ICommand>();

            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
        }

        public void AddSite(ArchaeologicalSite site)
        {
            ExecuteCommand(new AddSiteCmd(_siteRepository, site));
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
        }

        public void UpdateSite(ArchaeologicalSite oldSite, ArchaeologicalSite newSite)
        {
            ExecuteCommand(new EditSiteCmd(_siteRepository, oldSite, newSite));
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
        }

        public void DeleteSite(ArchaeologicalSite site)
        {
            ExecuteCommand(new DeleteSiteCmd(_siteRepository, site));
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
        }

        public void AddRecord(ExcavationRecord record)
        {
            _excRepository.Add(record);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
        }

        public void UpdateRecord(ExcavationRecord record)
        {
            _excRepository.Update(record);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
        }

        public void DeleteRecord(Guid id)
        {
            _excRepository.Delete(id);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
        }

        public void Undo()
        {
            if (_undoStack.Count == 0) return;
            ICommand cmd = _undoStack.Pop();
            cmd.Undo();
            _redoStack.Push(cmd);
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
        }

        public void Redo()
        {
            if (_redoStack.Count == 0) return;
            ICommand cmd = _redoStack.Pop();
            cmd.Execute();
            _undoStack.Push(cmd);
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
        }

        public void ExecuteCommand(ICommand cmd)
		{
            cmd.Execute();
            _undoStack.Push(cmd);
            _redoStack.Clear();
        }

        public void LoadData()
        {
            var sites = _persistenceService.LoadSites();
            var records = _persistenceService.LoadRecords();
            Sites = new ObservableCollection<ArchaeologicalSite>(sites);
            Records = new ObservableCollection<ExcavationRecord>(records);
        }

        public void SaveData()
        {
            _persistenceService.Save(Sites.ToList(), Records.ToList());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
