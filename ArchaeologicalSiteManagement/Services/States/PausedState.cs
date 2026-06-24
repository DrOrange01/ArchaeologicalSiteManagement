using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services.States
{
	public class PausedState : ExcavationStateBase
	{
        public PausedState(ExcavationRecord record)
        {
            _record = record;
        }
        public override void Handle()
		{
            StateChangeCheck();
        }

		protected override void StateChangeCheck()
		{
            _record.State = ExcavationState.Completed;
            _record.SetState(new CompletedState(_record));
        }
	}
}
