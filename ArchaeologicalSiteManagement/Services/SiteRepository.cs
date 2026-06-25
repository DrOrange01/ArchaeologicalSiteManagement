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

        public static readonly Guid ViminaciumId = Guid.NewGuid();
        public static readonly Guid LepenskiVirId = Guid.NewGuid();
        public static readonly Guid FelixRomukianaId = Guid.NewGuid();

        public SiteRepository()
        {
            _sites = new List<ArchaeologicalSite>
            {
                new ArchaeologicalSite { Id = ViminaciumId, Name = "Viminacium", Location = "Kostolac", Civilization = "Rimska", DiscoveryYear = 1882, SiteType = "Nekropola" },
                new ArchaeologicalSite { Id = LepenskiVirId, Name = "Lepenski Vir", Location = "Boljetin", Civilization = "Mezolitska", DiscoveryYear = 1965, SiteType = "Naselje" },
                new ArchaeologicalSite { Id = FelixRomukianaId, Name = "Felix Romuliana", Location = "Gamzigrad", Civilization = "Rimska", DiscoveryYear = 1953, SiteType = "Utvrdjenje" }
            };
        }

        public List<ArchaeologicalSite> GetAll()
		{
			return _sites;
		}

		public ArchaeologicalSite GetById(Guid id)
		{
            return _sites.FirstOrDefault(s => s.Id == id);
        }

		public void Add(ArchaeologicalSite site)
		{
            site.Id = Guid.NewGuid();
			_sites.Add(site);

        }

		public void Update(ArchaeologicalSite site)
		{
            int index = _sites.FindIndex(s => s.Id == site.Id);
            if (index >= 0)
                _sites[index] = site;
        }

		public void Delete(Guid id)
		{
            _sites.RemoveAll(s => s.Id == id);
        }
	}
}
