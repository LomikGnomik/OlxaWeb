﻿using Microsoft.Security.Application;
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

        //Save Post
        public void SavePost(Post post)
        {
            if (post.Id == 0)
            {
                post.PostedOn = DateTime.Now;
                post.Modified = DateTime.Now;
                context.Posts.Add(post);
            }
            else
            {
                Post dbEntry = context.Posts.Find(post.Id);
                if (dbEntry != null)
                {
                    dbEntry.Category = post.Category;
                    dbEntry.Description = Sanitizer.GetSafeHtmlFragment(post.Description);
                    dbEntry.Meta = post.Meta;
                    dbEntry.Modified = DateTime.Now;
                    dbEntry.Published = post.Published;
                    dbEntry.ShortDescription = post.ShortDescription;
                    dbEntry.Title = post.Title;
                    dbEntry.UrlSlug = post.UrlSlug;
                    dbEntry.Counter = post.Counter;
                    dbEntry.Picture = post.Picture;
                }
            }
            context.SaveChanges();
        }
        //Delete Post
        public Post DeletePost(int Id)
        {
            Post dbEntry = context.Posts.Find(Id);
            if (dbEntry != null)
            {
                context.Posts.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
        public Post PublishPost(int Id)
        {
            Post dbEntry = context.Posts.Find(Id);
            if (dbEntry != null)
            {
                dbEntry.Published = dbEntry.Published == true ? false : true;
                context.SaveChanges();
            }
            return dbEntry;
        }
        // TAG
        public IEnumerable<Tag> Tags
        {
            get { return context.Tags; }
        }
    }

}

