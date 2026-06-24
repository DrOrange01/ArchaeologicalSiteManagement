using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services.States
{
	public class CompletedState : ExcavationStateBase
	{
        public CompletedState(ExcavationRecord record)
        {
            _record = record;
        }
        public override void Handle()
		{
            StateChangeCheck();
        }

		protected override void StateChangeCheck()
		{
			// nema dalje jer je poslednje stanje
			throw new NotImplementedException();
		}
	}
}
