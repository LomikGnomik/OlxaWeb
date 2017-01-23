using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlxaWeb.Domain.Entities
{
   public class Temmplate               //Таблица где хранятся шаблонные сайты
    {
        public virtual int Id
        { get; set; }

        public virtual string Title
        { get; set; }
        [AllowHtml]
        public virtual string ShortDescription
        { get; set; }
        [AllowHtml]  //для безопасности от скриптов
        public virtual string Description
        { get; set; }

        public virtual decimal Price
        { get; set; }

        public virtual string Category
        { get; set; }

        public virtual string LinkDemo
        { get; set; }

        public virtual string LinkPicture
        { get; set; }

        public virtual bool Publish
        { get; set; }
    }
}
