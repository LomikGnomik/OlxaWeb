using OlxaWeb.Domain.Entities;
using System.Collections.Generic;

namespace OlxaWeb.Domain.Abstract
{
   public interface ITemplateRepository
    {
        IEnumerable<Temmplate> Temmplates { get; }
        void SaveTemplate(Temmplate Template);
        Temmplate DeleteTemplate(int Id);
    }
}
