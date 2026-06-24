using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;

namespace ArchaeologicalSiteManagement.Services
{
	public class ExcavationRepository : IExcavationRepository
	{
		List<ExcavationRecord> _records;
		List<IObserver> _observers;

		public List<ExcavationRecord> GetAll()
		{
			throw new NotImplementedException();
		}

		public List<ExcavationRecord> GetBySiteId(Guid siteId)
		{
			throw new NotImplementedException();
		}

		public List<ExcavationRecord> GetBySiteIdAndYear(Guid siteId, int year)
		{
			throw new NotImplementedException();
		}

		public void Add(ExcavationRecord record)
		{
			throw new NotImplementedException();
		}

		public void Update(ExcavationRecord record)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id)
		{
			throw new NotImplementedException();
		}

		public void RegisterObserver(IObserver o)
		{
			throw new NotImplementedException();
		}

		public void UnregisterObserver(IObserver o)
		{
			throw new NotImplementedException();
		}

		public void NotifyObservers()
		{
			throw new NotImplementedException();
		}
	}
}
