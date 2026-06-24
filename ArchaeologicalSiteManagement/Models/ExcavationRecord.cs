using ArchaeologicalSiteManagement.Services.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Models
{
	public class ExcavationRecord
	{
		public Guid Id { get; set; }

        public Guid SiteId { get; set; }

        public DateTime ExcavationDate { get; set; }

        public double AreaExcavatedM2 { get; set; }

		public double ArtifactsFound { get; set; }

        public double DepthReachedCm { get; set; }

		public ExcavationState State { get; set; }

        private ExcavationStateBase _stateBase;

        public void SetState(ExcavationStateBase newState)
		{
            _stateBase = newState;
        }

		public void SimulateNext()
		{
            _stateBase?.Handle();
        }
	}
}
