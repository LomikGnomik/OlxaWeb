using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Abstract
{
   public interface IBlogRepository
    {
        IEnumerable<Post> Posts { get; }
        IEnumerable<Tag> Tags { get; }
    }
}
