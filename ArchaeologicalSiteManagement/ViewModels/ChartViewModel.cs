using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ArchaeologicalSiteManagement.ViewModels
{
	public class ChartViewModel : IObserver, INotifyPropertyChanged
    {
		private List<ExcavationRecord> _records;
        public ObservableCollection<ISeries> Series { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public ChartViewModel()
        {
            _records = new List<ExcavationRecord>();
            Series = new ObservableCollection<ISeries>();
        }

        public void Update(List<ExcavationRecord> records)
		{
            _records = records;
            RefreshChart();
        }

		public void RefreshChart()
		{
            int active = _records.Count(r => r.State == ExcavationState.Active);
            int paused = _records.Count(r => r.State == ExcavationState.Paused);
            int completed = _records.Count(r => r.State == ExcavationState.Completed);
            int abandoned = _records.Count(r => r.State == ExcavationState.Abandoned);

            Series = new ObservableCollection<ISeries>
            {
                new PieSeries<int> { Values = new[] { active }, Name = "Active" },
                new PieSeries<int> { Values = new[] { paused }, Name = "Paused" },
                new PieSeries<int> { Values = new[] { completed }, Name = "Completed" },
                new PieSeries<int> { Values = new[] { abandoned }, Name = "Abandoned" }
            };

            OnPropertyChanged(nameof(Series));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
