using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Interfaces
{
	public interface ICommand
	{
		void Execute();

		void Undo();
	}
}
