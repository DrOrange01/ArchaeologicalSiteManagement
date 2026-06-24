using System;
using System.Collections.Generic;
using System.Text;
using ArchaeologicalSiteManagement.Models;
using ArchaeologicalSiteManagement.Interfaces;

namespace ArchaeologicalSiteManagement.Commands
{
	public abstract class SiteCommand : ICommand
	{
		protected ISiteRepository _repository;
		protected ArchaeologicalSite _site;

		public abstract void Execute();

		public abstract void Undo();
	}
}
