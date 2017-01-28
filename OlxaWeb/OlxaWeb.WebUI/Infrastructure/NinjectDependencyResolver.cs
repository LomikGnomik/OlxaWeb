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
            // Шаблонные
            Mock<ITemplateRepository> mock = new Mock<ITemplateRepository>();
            mock.Setup(m => m.Temmplates).Returns(new List<Temmplate> {
            new Temmplate {Title="Строительный",Description="", Category="Интернет-магазин", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=1 , Publish=true},
            new Temmplate {Title="Ресторанный",Description="", Category="Интернет-магазин", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=2,Publish=true },
            new Temmplate {Title="Медицинский",Description="", Category="Лендинг", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=3 ,Publish=false},
            new Temmplate {Title="Спортивный",Description="", Category="Корпаративный", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=4,Publish=true },
            new Temmplate {Title="Магазин",Description="", Category="капуста", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=5, Publish=false },
            new Temmplate {Title="Лендинг",Description="", Category="magazin", ShortDescription="", LinkDemo="", LinkPicture="", Price=100500 , Id=6,Publish=true }
            });
            kernel.Bind<ITemplateRepository>().ToConstant(mock.Object);

            // Блог
            Mock<IBlogRepository> mockblog = new Mock<IBlogRepository>();
            mockblog.Setup(m => m.Posts).Returns(new List<Post> {
            new Post {Id=1,
                Title ="Лучшие landing Page — подборка лучших интерактивных Landing Page",
                ShortDescription ="",Description="Если при прочтении книги Вам тяжело представить что там происходит, тогда данный сайт для Вас 🙂 . Потому что здесь Вы можете сразу и читать и видеть сюжет, потому что на фоне происходит то, что написано текстом. То есть по мере прокрутки страницы и чтения текста меняется и фон сайта.Интересная задумка. Кто знает, может в ближайшее время такие истории начнут появляться в больших масштабах. Конечно, есть плюсы и минусы у данного подхода, но то что это креативно сделано — нет претензий.",
                Meta ="",
                UrlSlug ="HiRes-Blank-Faces.jpg",
                Published =false,
                Category ="SEO",
                PostedOn =DateTime.Today,
                Modified =DateTime.Now,
                Counter=100
            },
            new Post {Id=6,Title="Лучшие landing",ShortDescription="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur.",Description="",Meta="",UrlSlug="HiRes-Blank-Faces.jpg",Published=true,Category="SEO",PostedOn=DateTime.Today, Modified=DateTime.Now,Counter=150 },
            new Post {Id=2,Title="Обосраться чтиво",ShortDescription="Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur.",Description="",Meta="",UrlSlug="1478172823164455436.png",Published=true,Category="Разработка",PostedOn=DateTime.Today, Modified=DateTime.Now,Counter=120 },
            new Post {Id=3,Title="Мега статья",ShortDescription="",Description="",Meta="",UrlSlug="image.jpg",Published=true,Category="О всяком",PostedOn=DateTime.Today, Modified=DateTime.Now,Counter=200 },
            new Post {Id=4,Title="Landing Page",ShortDescription="",Description="",Meta="",UrlSlug="",Published=true,Category="Ляля",PostedOn=DateTime.Today, Modified=DateTime.Now ,Counter=300 },
            new Post {Id=5,Title="Лучшие Landing",ShortDescription="",Description="",Meta="",UrlSlug="",Published=true,Category="SEO",PostedOn=DateTime.Today, Modified=DateTime.Now ,Counter=10 }
            });
            kernel.Bind<IBlogRepository>().ToConstant(mockblog.Object);

            // Портфолио
            Mock<IPortfolioRepository> mockportfolio = new Mock<IPortfolioRepository>();
            mockportfolio.Setup(m => m.Portfolios).Returns(new List<Portfolio> {
            new Portfolio {Id=1, Category="lan", Day=20, Description="", Name="OlxaWeb.ru", PictureMobile="", PicturePC="", Price=1000, Publish=true, URL=""},
            new Portfolio { Id = 2, Category = "lan", Day = 20, Description = "", Name = "DedPixto", PictureMobile = "", PicturePC = "", Price = 1000, Publish = true, URL = "" },
            new Portfolio { Id = 3, Category = "corp", Day = 20, Description = "", Name = "Какашка", PictureMobile = "", PicturePC = "", Price = 1000, Publish = false, URL = "" },
            new Portfolio {Id=4, Category="mag", Day=20, Description="", Name="", PictureMobile="", PicturePC="", Price=1000, Publish=false, URL=""},
            new Portfolio {Id=5, Category="lux", Day=20, Description="", Name="Сайт рецептов", PictureMobile="", PicturePC="", Price=1000, Publish=true, URL=""},
            new Portfolio {Id=6, Category="lux", Day=20, Description="", Name="Супер-пупер сайт", PictureMobile="", PicturePC="", Price=1000, Publish=true, URL=""}
            });
            kernel.Bind<IPortfolioRepository>().ToConstant(mockportfolio.Object);


            //kernel.Bind<IPortfolioRepository>().To<EFPortfolioRepository>();
            //kernel.Bind<ITemplateRepository>().To<EFTemplateRepository>();
            //kernel.Bind<IBlogRepository>().To<EFBlogRepository>();
            kernel.Bind<IWebSiteRepository>().To<EFWebSiteRepository>();
        }
    }

}