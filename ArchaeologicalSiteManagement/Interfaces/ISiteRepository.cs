using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Interfaces
{
	public interface ISiteRepository
	{
		List<ArchaeologicalSite> GetAll();

		ArchaeologicalSite GetById(Guid id);

		void Add(ArchaeologicalSite site);

		void Update(ArchaeologicalSite site);

		void Delete(Guid id);
	}
}
