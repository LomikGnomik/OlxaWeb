using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Concrete
{
   public class EFTemplateRepository :ITemplateRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Template> Templates
        {
            get { return context.Templates; }
        }
    }
}
