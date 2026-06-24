using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Commands
{
	public class DeleteSiteCmd : SiteCommand
	{
        public DeleteSiteCmd(ISiteRepository repository, ArchaeologicalSite site)
        {
            _repository = repository;
            _site = site;
        }
        public override void Execute()
		{
            _repository.Delete(_site.Id);
        }

		public override void Undo()
		{
            _repository.Add(_site);
        }
	}
}
