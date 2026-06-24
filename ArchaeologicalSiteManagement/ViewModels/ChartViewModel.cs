using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;

namespace ArchaeologicalSiteManagement.ViewModels
{
	public class ChartViewModel : IObserver
	{
		List<ExcavationRecord> _records;

		public void Update(List<ExcavationRecord> records)
		{
			throw new NotImplementedException();
		}

		public void RefreshChart()
		{
			throw new NotImplementedException();
		}
	}
}
