using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArchaeologicalSiteManagement.WCF
{
    public interface IArchaeologicalService
    {
        public List<ArchaeologicalSite> GetAllSites();

        public List<ExcavationRecord> GetExcavationRecords(Guid siteId, int year);
    }
}
