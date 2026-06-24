using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services.States
{
	public class ActiveState : ExcavationStateBase
	{
        public ActiveState(ExcavationRecord record)
        {
            _record = record;
        }
        public override void Handle()
		{
            StateChangeCheck();
        }

		protected override void StateChangeCheck()
		{
            _record.State = ExcavationState.Paused;
            _record.SetState(new PausedState(_record));
        }
	}
}
