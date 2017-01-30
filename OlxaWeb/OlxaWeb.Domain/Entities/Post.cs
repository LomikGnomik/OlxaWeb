using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlxaWeb.Domain.Entities
{
   public class Post
    {
        [HiddenInput(DisplayValue = false)]
        public virtual int Id
        { get; set; }

        [Display(Name = "Заголовок")]
        public virtual string Title
        { get; set; }

        [AllowHtml]
        [Display(Name = "Короткое описание")]
        public virtual string ShortDescription
        { get; set;}

        [Display(Name = "Описание")]
        [AllowHtml]
        public virtual string Description
        { get; set; }

        [Display(Name = "Мета")]
        public virtual string Meta
        { get; set; }

        [Display(Name = "")]
        public virtual string UrlSlug
        { get; set; }

        [Display(Name = "Опубликованно?")]
        public virtual bool Published
        { get; set; }

        [Display(Name = "Категория")]
        public virtual string Category
        { get; set; }

        //[DataType(DataType.Date)]
        //[Display(Name = "Дата написания поста")]
        //public virtual DateTime PostedOn
        //{ get; set; }

        //[DataType(DataType.Date)]
        //[Display(Name = "Пост изменён")]
        //public virtual DateTime? Modified
        //{ get; set; }

        [Display(Name = "Количество просмотров")]
        public virtual int Counter //счётчик просмотров
        { get; set; }

        [Display(Name = "Изображение")]
        public virtual string Picture
        { get; set; }

        public virtual IList<Tag> Tags
        { get; set; }
    }
}
