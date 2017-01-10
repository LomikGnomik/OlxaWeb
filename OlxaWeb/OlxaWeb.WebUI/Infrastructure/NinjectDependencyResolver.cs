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
            kernel.Bind<IBlogRepository>().To<EFBlogRepository>();

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
            // kernel.Bind<ITemplateRepository>().To<EFTemplateRepository>();
        }
    }

}