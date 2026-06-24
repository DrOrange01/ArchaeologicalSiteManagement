using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Commands
{
	public class AddSiteCmd : SiteCommand
	{
        public AddSiteCmd(ISiteRepository repository, ArchaeologicalSite site)
        {
            _repository = repository;
            _site = site;
        }
        public override void Execute()
		{
            _repository.Add(_site);
        }

		public override void Undo()
		{
            _repository.Delete(_site.Id);
        }
	}
}
