using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;


namespace ArchaeologicalSiteManagement.Services
{
	public class SiteRepository : ISiteRepository
	{
		List<ArchaeologicalSite> _sites;

		public List<ArchaeologicalSite> GetAll()
		{
			throw new NotImplementedException();
		}

		public ArchaeologicalSite GetById(Guid id)
		{
			throw new NotImplementedException();
		}

		public void Add(ArchaeologicalSite site)
		{
			throw new NotImplementedException();
		}

		public void Update(ArchaeologicalSite site)
		{
			throw new NotImplementedException();
		}

		public void Delete(Guid id)
		{
			throw new NotImplementedException();
		}
	}
}
