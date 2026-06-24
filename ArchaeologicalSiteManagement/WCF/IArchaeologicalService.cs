using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using CoreWCF;


namespace ArchaeologicalSiteManagement.WCF
{
    [ServiceContract]
    public interface IArchaeologicalService
    {
        [OperationContract]
        public List<ArchaeologicalSite> GetAllSites();
        [OperationContract]
        public List<ExcavationRecord> GetExcavationRecords(Guid siteId, int year);
    }
}
