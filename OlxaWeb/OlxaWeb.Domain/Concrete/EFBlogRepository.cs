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
        public void SavePost(Post post)
        {
            if (post.Id == 0)
            {
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts.Find(post.Id);
                if (dbEntry != null)
                {
                    dbEntry.Category = post.Category;
                    dbEntry.Description = post.Description;
                    dbEntry.Meta = post.Meta;
                    dbEntry.Modified = DateTime.Now;
                    dbEntry.PostedOn = post.PostedOn;
                    dbEntry.Published = post.Published;
                    dbEntry.ShortDescription = post.ShortDescription;
                    dbEntry.Title = post.Title;
                    dbEntry.UrlSlug = post.UrlSlug;
                }
            }
            context.SaveChanges();
        }
        public IEnumerable<Tag> Tags
        {
            get { return context.Tags; }
        }
    }

}

