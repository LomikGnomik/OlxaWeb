using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OlxaWeb.Domain.Entities
{
   public class Temmplate               //Таблица где хранятся шаблонные сайты
    {
        [HiddenInput(DisplayValue = false)]
        public virtual int Id
        { get; set; }

        [Required]
        [Display(Name = "Название")]
        public virtual string Title
        { get; set; }

        [AllowHtml]
        [Display(Name = "Короткое описание")]
        public virtual string ShortDescription
        { get; set; }

        [AllowHtml]   //для безопасности от скриптов
        [DataType(DataType.MultilineText)]
        [Display(Name = "Описание")]
        public virtual string Description
        { get; set; }

        [Display(Name = "Цена")]
        public virtual decimal Price
        { get; set; }

        [Display(Name = "Категория")]
        public virtual string Category
        { get; set; }

        [Display(Name = "Ссылка на демо")]
        public virtual string LinkDemo
        { get; set; }

        [Display(Name = "Название картинки в папке \\Content\\img\\TemplateSitePicture\\")]
        public virtual string LinkPicture
        { get; set; }

        [Display(Name = "Опубликован?")]
        public virtual bool Publish
        { get; set; }
    }
}
