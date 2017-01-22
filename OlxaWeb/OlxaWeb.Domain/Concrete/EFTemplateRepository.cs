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

        public IEnumerable<Temmplate> Temmplates
        {
            get { return context.Temmplates; }
        }

        public void SaveTemplate(Temmplate template)
        {
            if (template.Id == 0)
            {
                context.Temmplates.Add(template);
            }
            else
            {
                Temmplate dbEntry = context.Temmplates.Find(template.Id);
                if (dbEntry != null)
                {
                    dbEntry.Category = template.Category;
                    dbEntry.Description = template.Description;
                    dbEntry.LinkDemo = template.LinkDemo;
                    dbEntry.LinkPicture = template.LinkPicture;
                    dbEntry.Price = (decimal)template.Price;
                    dbEntry.Publish = template.Publish;
                    dbEntry.ShortDescription = template.ShortDescription;
                    dbEntry.Title = template.Title;
                }
            }
            context.SaveChanges();
        }
        //Delete Template
        public Temmplate DeleteTemplate(int Id)
        {
            Temmplate dbEntry = context.Temmplates.Find(Id);
            if (dbEntry != null)
            {
                context.Temmplates.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
