using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArchaeologicalSiteManagement.Interfaces;
using System.IO;

namespace ArchaeologicalSiteManagement.Helpers
{
    public class FileLogger : ILogger
    {
        private readonly string _filePath = "log.txt";

        public void Log(string message)
        {
            string logEntry = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - {message}";
            File.AppendAllText(_filePath, logEntry + Environment.NewLine);
        }
    }
}
