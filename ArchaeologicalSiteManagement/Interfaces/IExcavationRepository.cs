using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;

namespace ArchaeologicalSiteManagement.Interfaces
{
	public interface IExcavationRepository
	{
		List<ExcavationRecord> GetAll();

		List<ExcavationRecord> GetBySiteId(Guid siteId);

		List<ExcavationRecord> GetBySiteIdAndYear(Guid siteId, int year);

		void Add(ExcavationRecord record);

		void Update(ExcavationRecord record);

		void Delete(Guid id);
		public void RegisterObserver(IObserver o);
		public void UnregisterObserver(IObserver o);

		public void NotifyObservers();
    }
}
