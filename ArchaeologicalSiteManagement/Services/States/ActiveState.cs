using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services.States
{
	public abstract class ActiveState : ExcavationStateBase
	{
		public override void Handle()
		{
			throw new NotImplementedException();
		}

		protected override void StateChangeCheck()
		{
			throw new NotImplementedException();
		}
	}
}
