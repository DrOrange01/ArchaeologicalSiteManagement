using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;

namespace ArchaeologicalSiteManagement.WCF
{
	public class ArchaeologicalService : IArchaeologicalService
    {
        private ISiteRepository _siteRepository;
        private IExcavationRepository _excRepository;

        public ArchaeologicalService(ISiteRepository siteRepository, IExcavationRepository excRepository)
        {
            _siteRepository = siteRepository;
            _excRepository = excRepository;
        }

        public List<ArchaeologicalSite> GetAllSites()
		{
            return _siteRepository.GetAll();
        }

		public List<ExcavationRecord> GetExcavationRecords(Guid siteId, int year)
		{
            return _excRepository.GetBySiteIdAndYear(siteId, year);

        }
	}
}
