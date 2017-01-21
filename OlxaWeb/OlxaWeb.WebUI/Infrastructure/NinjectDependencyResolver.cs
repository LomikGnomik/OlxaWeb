using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Moq;
using OlxaWeb.Domain.Abstract;
using OlxaWeb.Domain.Concrete;
using OlxaWeb.Domain.Entities;

namespace OlxaWeb.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            Mock<ITemplateRepository> mock = new Mock<ITemplateRepository>();
            mock.Setup(m => m.Temmplates).Returns(new List<Temmplate> {
            new Temmplate {Title="Строительный",Description="", Category="lending", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=1 },
            new Temmplate {Title="Ресторанный",Description="", Category="lending", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=2 },
            new Temmplate {Title="Медицинский",Description="", Category="magazin", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=3 },
            new Temmplate {Title="Спортивный",Description="", Category="comercy", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=4 },
            new Temmplate {Title="Магазин",Description="", Category="magazin", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=5 },
            new Temmplate {Title="Лендинг",Description="", Category="magazin", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=6 }
            });
            kernel.Bind<ITemplateRepository>().ToConstant(mock.Object);


            Mock<IBlogRepository> mockblog = new Mock<IBlogRepository>();
            mockblog.Setup(m => m.Posts).Returns(new List<Post> {
            new Post {Id=1,Title="Лучшие Landing Page — подборка лучших интерактивных Landing Page",ShortDescription="",Description="Если при прочтении книги Вам тяжело представить что там происходит, тогда данный сайт для Вас 🙂 . Потому что здесь Вы можете сразу и читать и видеть сюжет, потому что на фоне происходит то, что написано текстом. То есть по мере прокрутки страницы и чтения текста меняется и фон сайта.Интересная задумка. Кто знает, может в ближайшее время такие истории начнут появляться в больших масштабах. Конечно, есть плюсы и минусы у данного подхода, но то что это креативно сделано — нет претензий.",Meta="",UrlSlug="HiRes-Blank-Faces.jpg",Published=true,Category="SEO",PostedOn=DateTime.Today, Modified=DateTime.Now },
            new Post {Id=6,Title="",ShortDescription="",Description="",Meta="",UrlSlug="HiRes-Blank-Faces.jpg",Published=true,Category="SEO",PostedOn=DateTime.Today, Modified=DateTime.Now },
            new Post {Id=2,Title="",ShortDescription="",Description="",Meta="",UrlSlug="1478172823164455436.png",Published=true,Category="Разработка",PostedOn=DateTime.Today, Modified=DateTime.Now },
            new Post {Id=3,Title="",ShortDescription="",Description="",Meta="",UrlSlug="image.jpg",Published=true,Category="О всяком",PostedOn=DateTime.Today, Modified=DateTime.Now },
            new Post {Id=4,Title="",ShortDescription="",Description="",Meta="",UrlSlug="",Published=true,Category="Ляля",PostedOn=DateTime.Today, Modified=DateTime.Now },
            new Post {Id=5,Title="",ShortDescription="",Description="",Meta="",UrlSlug="",Published=true,Category="SEO",PostedOn=DateTime.Today, Modified=DateTime.Now }
            });
            kernel.Bind<IBlogRepository>().ToConstant(mockblog.Object);

            // kernel.Bind<ITemplateRepository>().To<EFTemplateRepository>();
            //kernel.Bind<IBlogRepository>().To<EFBlogRepository>();
            kernel.Bind<IWebSiteRepository>().To<EFWebSiteRepository>();
        }
    }

}