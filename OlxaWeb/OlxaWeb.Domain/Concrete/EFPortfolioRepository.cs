using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Concrete
{
   public class EFPortfolioRepository : IPortfolioRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Portfolio> Portfolios
        {
            get { return context.Portfolios; }
        }

        public void SavePortfolio(Portfolio portfolio)
        {
            if (portfolio.Id == 0)
            {
                context.Portfolios.Add(portfolio);
            }
            else
            {
                Portfolio dbEntry = context.Portfolios.Find(portfolio.Id);
                if (dbEntry != null)
                {
                    dbEntry.Category = portfolio.Category;
                    dbEntry.Description = portfolio.Description;
                    dbEntry.Day = portfolio.Day;
                    dbEntry.Name = portfolio.Name;
                    dbEntry.PictureMobile = portfolio.PictureMobile;
                    dbEntry.PicturePC = portfolio.PicturePC;
                    dbEntry.Price = portfolio.Price;
                    dbEntry.Publish = portfolio.Publish;
                    dbEntry.URL = portfolio.URL;
                }
            }
            context.SaveChanges();
        }
        //Delete Portfolio
        public Portfolio DeletePortfolio(int Id)
        {
            Portfolio dbEntry = context.Portfolios.Find(Id);
            if (dbEntry != null)
            {
                context.Portfolios.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }

    }
}
