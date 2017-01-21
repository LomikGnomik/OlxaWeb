using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OlxaWeb.Domain.Entities
{
  public class Portfolio
    {
        public virtual int Id
        { get;set;}

        public virtual string Name
        { get; set; }

        public virtual string Category
        { get; set; }

        public virtual string URL
        { get; set; }

        public virtual decimal Price
        { get; set; }

        public virtual string PicturePC //скрин с компа
        { get; set; }

        public virtual string PictureMobile //скрин с мобилы
        { get; set; }

        public virtual string Description
        { get; set; }

        public virtual int  Day // срок исполнения
        { get; set; }

        public virtual bool Publish { get; set; } // опубликован?
    }
}
