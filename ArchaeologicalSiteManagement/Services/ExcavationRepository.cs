using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Services.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services
{
	public class ExcavationRepository : IExcavationRepository
	{
		List<ExcavationRecord> _records;
		List<IObserver> _observers;

        public ExcavationRepository()
        {
            _observers = new List<IObserver>();
            _records = new List<ExcavationRecord>
            {
                new ExcavationRecord { Id = Guid.NewGuid(), SiteId = SiteRepository.ViminaciumId, ExcavationDate = new DateTime(2024, 5, 10), AreaExcavatedM2 = 12.5, ArtifactsFound = 7, DepthReachedCm = 180, State = ExcavationState.Active },
                new ExcavationRecord { Id = Guid.NewGuid(), SiteId = SiteRepository.LepenskiVirId, ExcavationDate = new DateTime(2024, 6, 15), AreaExcavatedM2 = 8.0, ArtifactsFound = 3, DepthReachedCm = 145, State = ExcavationState.Paused },
                new ExcavationRecord { Id = Guid.NewGuid(), SiteId = SiteRepository.FelixRomukianaId, ExcavationDate = new DateTime(2024, 7, 20), AreaExcavatedM2 = 20.0, ArtifactsFound = 12, DepthReachedCm = 210, State = ExcavationState.Completed }
            };

            foreach (var record in _records)
                record.SetState(new ActiveState(record));
        }
        public List<ExcavationRecord> GetAll()
		{
            return _records;
        }

		public List<ExcavationRecord> GetBySiteId(Guid siteId)
		{
            return _records.Where(r => r.SiteId == siteId).ToList();
        }

		public List<ExcavationRecord> GetBySiteIdAndYear(Guid siteId, int year)
		{
            return _records.Where(r => r.SiteId == siteId && r.ExcavationDate.Year == year).ToList();
        }

		public void Add(ExcavationRecord record)
		{
            record.Id = Guid.NewGuid();
            record.SetState(new ActiveState(record));
            _records.Add(record);
            NotifyObservers();
        }

		public void Update(ExcavationRecord record)
		{
            int index = _records.FindIndex(r => r.Id == record.Id);
            if (index >= 0)
                _records[index] = record;
            NotifyObservers();
        }

		public void Delete(Guid id)
		{
            _records.RemoveAll(r => r.Id == id);
            NotifyObservers();
        }

		public void RegisterObserver(IObserver o)
		{
            _observers.Add(o);
        }

		public void UnregisterObserver(IObserver o)
		{
            _observers.Remove(o);
        }

		public void NotifyObservers()
		{
            foreach (var observer in _observers)
                observer.Update(_records);
        }
	}
}
