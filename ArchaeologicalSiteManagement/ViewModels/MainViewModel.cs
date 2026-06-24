using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;
using System.Collections.ObjectModel;

namespace ArchaeologicalSiteManagement.ViewModels
{
	public class MainViewModel
	{
		ISiteRepository _siteRepository;
		IExcavationRepository _excRepository;
		IPersistenceService _persistenceService;
		Stack<ICommand> _undoStack;
		Stack<ICommand> _redoStack;

		public ObservableCollection<ArchaeologicalSite> Sites
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public ObservableCollection<ExcavationRecord> Records
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void AddSite()
		{
			throw new NotImplementedException();
		}

		public void UpdateSite()
		{
			throw new NotImplementedException();
		}

		public void DeleteSite()
		{
			throw new NotImplementedException();
		}

		public void AddRecord()
		{
			throw new NotImplementedException();
		}

		public void UpdateRecord()
		{
			throw new NotImplementedException();
		}

		public void DeleteRecord()
		{
			throw new NotImplementedException();
		}

		public void Undo()
		{
			throw new NotImplementedException();
		}

		public void Redo()
		{
			throw new NotImplementedException();
		}

		public void ExecuteCommand(ICommand cmd)
		{
			throw new NotImplementedException();
		}

		public void LoadData()
		{
			throw new NotImplementedException();
		}

		public void SaveData()
		{
			throw new NotImplementedException();
		}
	}
}
