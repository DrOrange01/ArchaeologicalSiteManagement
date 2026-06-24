using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Commands
{
	public abstract class AddSiteCmd : SiteCommand
	{
		public override void Execute()
		{
			throw new NotImplementedException();
		}

		public override void Undo()
		{
			throw new NotImplementedException();
		}
	}
}
