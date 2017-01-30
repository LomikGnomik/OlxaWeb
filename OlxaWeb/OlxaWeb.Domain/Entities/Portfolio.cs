using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlxaWeb.Domain.Entities
{
  public class Portfolio
    {
        public virtual int Id
        { get;set;}

        [Display(Name = "Название")]
        public virtual string Name
        { get; set; }

        [Display(Name = "Категория")]
        public virtual string Category
        { get; set; }

        [Display(Name = "Ссылка на сайт")]
        public virtual string URL
        { get; set; }

        [Display(Name = "Цена")]
        public virtual decimal Price
        { get; set; }

        [Display(Name = "Скрин с браузера компа")]
        public virtual string PicturePC //скрин с компа
        { get; set; }

        [Display(Name = "Скрин с браузера мобильного")]
        public virtual string PictureMobile //скрин с мобилы
        { get; set; }

        [Display(Name = "Описание")]
        [AllowHtml]
        public virtual string Description
        { get; set; }

        [Display(Name = "Короткое описание")]
        [AllowHtml]
        public virtual string  ShortDescription
        { get; set; }

        [Display(Name = "Срок исполнения")]
        public virtual int  Day // срок исполнения
        { get; set; }

        [Display(Name = "Опубликован")]
        public virtual bool Publish
        { get; set; } // опубликован?
    }
}
