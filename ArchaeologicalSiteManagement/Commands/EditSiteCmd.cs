using ArchaeologicalSiteManagement.Interfaces;
using ArchaeologicalSiteManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchaeologicalSiteManagement.Commands
{
	public class EditSiteCmd : SiteCommand
	{
        private ArchaeologicalSite _oldSite;

        public EditSiteCmd(ISiteRepository repository, ArchaeologicalSite oldSite, ArchaeologicalSite newSite)
        {
            _repository = repository;
            _oldSite = oldSite;
            _site = newSite;
        }
        public override void Execute()
		{
            _repository.Update(_site);
        }

		public override void Undo()
		{
            _repository.Update(_oldSite);
        }
	}
}
