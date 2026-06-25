using ArchaeologicalSiteManagement.Commands;
using ArchaeologicalSiteManagement.Helpers;
using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;

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

        private ArchaeologicalSite _selectedSite;
        private ExcavationRecord _selectedRecord;
        private ArchaeologicalSite _formSite;
        private ExcavationRecord _formRecord;
        private string _searchSite;
        private ILogger _logger;

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
        public string SearchSite
        {
            get { return _searchSite; }
            set
            {
                _searchSite = value;
                OnPropertyChanged(nameof(SearchSite));
                FilterSites();
            }
        }

        private void FilterSites()
        {
            if (string.IsNullOrWhiteSpace(_searchSite))
            {
                Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
                return;
            }

            var filtered = _siteRepository.GetAll().Where(s =>
                s.Name.Contains(_searchSite, StringComparison.OrdinalIgnoreCase) ||
                s.Location.Contains(_searchSite, StringComparison.OrdinalIgnoreCase) ||
                s.Civilization.Contains(_searchSite, StringComparison.OrdinalIgnoreCase) ||
                s.DiscoveryYear.ToString().Contains(_searchSite) ||
                s.SiteType.Contains(_searchSite, StringComparison.OrdinalIgnoreCase)
            ).ToList();

            Sites = new ObservableCollection<ArchaeologicalSite>(filtered);
        }
        public void SimulateNext()
        {
            if (SelectedRecord == null) return;

            if (SelectedRecord.State == ExcavationState.Completed || SelectedRecord.State == ExcavationState.Abandoned)
            {
                MessageBox.Show("This record is already in its last state.", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            SelectedRecord.SimulateNext();
            _excRepository.Update(SelectedRecord);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
            _logger.Log($"Simulation state for record: {SelectedRecord.Id}, new state: {SelectedRecord.State}");
        }

        public ArchaeologicalSite SelectedSite
        {
            get { return _selectedSite; }
            set
            {
                _selectedSite = value;
                OnPropertyChanged(nameof(SelectedSite));
            }
        }
        
        public ExcavationRecord SelectedRecord
        {
            get { return _selectedRecord; }
            set
            {
                _selectedRecord = value;
                OnPropertyChanged(nameof(SelectedRecord));
            }
        }

        public ArchaeologicalSite FormSite
        {
            get { return _formSite; }
            set { _formSite = value; OnPropertyChanged(nameof(FormSite)); }
        }

        public ExcavationRecord FormRecord
        {
            get { return _formRecord; }
            set { _formRecord = value; OnPropertyChanged(nameof(FormRecord)); }
        }
        public MainViewModel(ISiteRepository siteRepository, IExcavationRepository excRepository, IPersistenceService persistenceService)
        {
            _siteRepository = siteRepository;
            _excRepository = excRepository;
            _persistenceService = persistenceService;
            _undoStack = new Stack<ICommand>();
            _redoStack = new Stack<ICommand>();
            FormSite = new ArchaeologicalSite();
            FormRecord = new ExcavationRecord();
            ChartVM = new ChartViewModel();
            _excRepository.RegisterObserver(ChartVM);
            ChartVM.Update(_excRepository.GetAll());
            _logger = new FileLogger();

            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
        }

        public void AddSite(ArchaeologicalSite site)
        {
            var newSite = new ArchaeologicalSite
            {
                Id = Guid.NewGuid(),
                Name = site.Name,
                Location = site.Location,
                Civilization = site.Civilization,
                DiscoveryYear = site.DiscoveryYear,
                SiteType = site.SiteType
            };

            ExecuteCommand(new AddSiteCmd(_siteRepository, newSite));
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
            FormSite = new ArchaeologicalSite();

            _logger.Log($"Site added: {newSite.Name}");
        }

        public void UpdateSite(ArchaeologicalSite oldSite, ArchaeologicalSite newSite)
        {
            var updatedSite = new ArchaeologicalSite
            {
                Id = oldSite.Id,
                Name = newSite.Name,
                Location = newSite.Location,
                Civilization = newSite.Civilization,
                DiscoveryYear = newSite.DiscoveryYear,
                SiteType = newSite.SiteType
            };

            ExecuteCommand(new EditSiteCmd(_siteRepository, oldSite, updatedSite));
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());
            FormSite = new ArchaeologicalSite();

            _logger.Log($"Site updated: {updatedSite.Name}");
        }

        public void DeleteSite(ArchaeologicalSite site)
        {
            ExecuteCommand(new DeleteSiteCmd(_siteRepository, site));
            Sites = new ObservableCollection<ArchaeologicalSite>(_siteRepository.GetAll());

            _logger.Log($"Site delted: {site.Name}");
        }

        public void AddRecord(ExcavationRecord record)
        {
            var newRecord = new ExcavationRecord
            {
                Id = Guid.NewGuid(),
                SiteId = record.SiteId,
                ExcavationDate = record.ExcavationDate,
                AreaExcavatedM2 = record.AreaExcavatedM2,
                ArtifactsFound = record.ArtifactsFound,
                DepthReachedCm = record.DepthReachedCm,
                State = record.State
            };

            _excRepository.Add(newRecord);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
            FormRecord = new ExcavationRecord();

            _logger.Log($"Added excavation record for SiteId: {record.SiteId}");
        }

        public void UpdateRecord(ExcavationRecord record)
        {
            var updatedRecord = new ExcavationRecord
            {
                Id = record.Id,
                SiteId = record.SiteId,
                ExcavationDate = record.ExcavationDate,
                AreaExcavatedM2 = record.AreaExcavatedM2,
                ArtifactsFound = record.ArtifactsFound,
                DepthReachedCm = record.DepthReachedCm,
                State = record.State
            };

            _excRepository.Update(updatedRecord);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());
            FormRecord = new ExcavationRecord();

            _logger.Log($"Excavation record updated: {record.Id}");
        }

        public void DeleteRecord(Guid id)
        {
            _excRepository.Delete(id);
            Records = new ObservableCollection<ExcavationRecord>(_excRepository.GetAll());

            _logger.Log($"Excavation record deleted: {id}");
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

        public bool ValidateSite(ArchaeologicalSite site)
        {
            return !string.IsNullOrWhiteSpace(site.Name)
                && !string.IsNullOrWhiteSpace(site.Location)
                && !string.IsNullOrWhiteSpace(site.Civilization)
                && site.DiscoveryYear > 0
                && !string.IsNullOrWhiteSpace(site.SiteType);
        }

        public ChartViewModel ChartVM { get; set; }

        public IEnumerable<ExcavationState> ExcavationStates => Enum.GetValues(typeof(ExcavationState)).Cast<ExcavationState>();

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
