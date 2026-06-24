using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;

namespace ArchaeologicalSiteManagement.Interfaces
{
	public interface IPersistenceService
	{
		void Save(List<ArchaeologicalSite> sites, List<ExcavationRecord> records);

		void Load();
	}
}
