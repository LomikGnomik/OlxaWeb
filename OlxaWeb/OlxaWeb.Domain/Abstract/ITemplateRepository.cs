using OlxaWeb.Domain.Entities;
using System.Collections.Generic;

namespace OlxaWeb.Domain.Abstract
{
   public interface ITemplateRepository
    {
        IEnumerable<Template> Templates { get; }
    }
}
