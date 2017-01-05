using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Concrete
{
   public class EFBlogRepository: IBlogRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Post> Posts
        {
            get { return context.Posts; }
        }
        public IEnumerable<Category> Categoryes
        {
            get { return context.Categoryes; }
        }
        public IEnumerable<Tag> Tags
        {
            get { return context.Tags; }
        }
    }

}

