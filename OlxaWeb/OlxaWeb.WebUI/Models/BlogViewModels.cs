using OlxaWeb.Domain.Entities;
using System.Collections.Generic;

namespace OlxaWeb.WebUI.Models
{
    public class BlogViewModels
    {
        public IEnumerable<Post> Posts { get; set; }
        public IEnumerable<Post> MaxViewPosts { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentCategory { get; set; }
        public string SearchString { get; set; }
    }
}