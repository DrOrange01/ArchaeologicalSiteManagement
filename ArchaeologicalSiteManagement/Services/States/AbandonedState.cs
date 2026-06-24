using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services.States
{
	public class AbandonedState : ExcavationStateBase
	{
        public AbandonedState(ExcavationRecord record)
        {
            _record = record;
        }
        public override void Handle()
		{
            StateChangeCheck();
        }

		protected override void StateChangeCheck()
		{
			// isto ko za completed
			throw new NotImplementedException();
		}
	}
}
