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
        void SavePost(Post post);
        Post DeletePost(int Id);
        Post PublishPost(int Id);

        IEnumerable<Tag> Tags { get; }
    }
}
