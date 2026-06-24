using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Services.States
{
	public abstract class ExcavationStateBase
	{
		protected ExcavationRecord _record;

		public abstract void Handle();

		protected abstract void StateChangeCheck();
	}
}
