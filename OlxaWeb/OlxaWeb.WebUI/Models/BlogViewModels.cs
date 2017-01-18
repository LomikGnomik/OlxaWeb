using OlxaWeb.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OlxaWeb.WebUI.Models
{
    public class BlogViewModels
    {
       public IEnumerable<Post> Posts { get; set; }
       public PagingInfo PagingInfo { get; set; }
       public string CurrentCategory { get; set; }
    }
}