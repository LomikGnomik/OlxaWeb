using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Concrete
{
   public class EFWebSiteRepository : IWebSiteRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<WebSite> WebSites
        {
            get { return context.WebSites; }
        }
    }
}
