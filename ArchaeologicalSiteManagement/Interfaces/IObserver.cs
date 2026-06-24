using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;

namespace ArchaeologicalSiteManagement.Interfaces
{
	public interface IObserver
	{
		void Update(List<ExcavationRecord> records);
	}
}
