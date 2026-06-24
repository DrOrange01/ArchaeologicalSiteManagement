using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Models
{
	public class ArchaeologicalSite
	{
		public Guid Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public string Civilization { get; set; }

        public int DiscoveryYear { get; set; }

        public string SiteType { get; set; }
    }
}
