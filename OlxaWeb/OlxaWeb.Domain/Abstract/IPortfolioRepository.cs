using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Abstract
{
   public interface IPortfolioRepository
    {
        IEnumerable<Portfolio> Portfolios { get; }
        void SavePortfolio(Portfolio portfolio);
        Portfolio DeletePortfolio(int Id);
    }
}
