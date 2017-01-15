using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Abstract
{
   public interface IWebSiteRepository
    {
      IEnumerable<WebSite> WebSites { get; }
    }
}
