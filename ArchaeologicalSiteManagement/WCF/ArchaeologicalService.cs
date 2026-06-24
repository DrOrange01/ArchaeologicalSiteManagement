using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;

namespace ArchaeologicalSiteManagement.WCF
{
	public class ArchaeologicalService : IArchaeologicalService
    {
		ISiteRepository _siteRepository;
		IExcavationRepository _excRepository;

		public List<ArchaeologicalSite> GetAllSites()
		{
			throw new NotImplementedException();
		}

		public List<ExcavationRecord> GetExcavationRecords(Guid siteId, int year)
		{
			throw new NotImplementedException();
		}
	}
}
