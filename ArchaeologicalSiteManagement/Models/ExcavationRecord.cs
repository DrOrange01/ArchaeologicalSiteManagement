using ArchaeologicalSiteManagement.Services.States;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Models
{
	public class ExcavationRecord
	{
		public Guid Id
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public guid SiteId
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public DateTime ExcavationDate
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public double AreaExcavatedM2
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public double ArtifactsFound
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public double DepthReachedCm
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		private ExcavationState state
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void SetState(ExcavationStateBase newState)
		{
			throw new NotImplementedException();
		}

		public void SimulateNext()
		{
			throw new NotImplementedException();
		}
	}
}
