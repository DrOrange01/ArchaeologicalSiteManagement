using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ArchaeologicalSiteManagement.Services
{
    public class PersistenceService : IPersistenceService
    {
        private readonly string _sitesFilePath = "sites.xml";
        private readonly string _recordsFilePath = "records.xml";

        public void Save(List<ArchaeologicalSite> sites, List<ExcavationRecord> records)
        {
            XmlSerializer siteSerializer = new XmlSerializer(typeof(List<ArchaeologicalSite>));
            using (StreamWriter writer = new StreamWriter(_sitesFilePath))
            {
                siteSerializer.Serialize(writer, sites);
            }

            XmlSerializer recordSerializer = new XmlSerializer(typeof(List<ExcavationRecord>));
            using (StreamWriter writer = new StreamWriter(_recordsFilePath))
            {
                recordSerializer.Serialize(writer, records);
            }
        }

        public List<ArchaeologicalSite> LoadSites()
        {
            if (!File.Exists(_sitesFilePath))
                return new List<ArchaeologicalSite>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ArchaeologicalSite>));
            using (StreamReader reader = new StreamReader(_sitesFilePath))
            {
                return (List<ArchaeologicalSite>)serializer.Deserialize(reader);
            }
        }

        public List<ExcavationRecord> LoadRecords()
        {
            if (!File.Exists(_recordsFilePath))
                return new List<ExcavationRecord>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<ExcavationRecord>));
            using (StreamReader reader = new StreamReader(_recordsFilePath))
            {
                return (List<ExcavationRecord>)serializer.Deserialize(reader);
            }
        }
    }
}
