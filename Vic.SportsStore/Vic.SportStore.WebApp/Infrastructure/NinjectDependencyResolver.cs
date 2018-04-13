using Moq;
using Ninject;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;
using Vic.SportsStore.Domain.Concrete;
using Vic.SportsStore.Domain.Entities;
using Vic.SportsStore.WebApp.Abstract;
using Vic.SportsStore.WebApp.Concrete;

namespace Vic.SportsStore.WebApp.Infrastructure
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
//        private void AddBindings()
//        {
//            // add bindings here
////            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
////            mock.Setup(m => m.Products).Returns(new List<Product>
////{
////new Product { Name = "Football", Price = 25 },
////new Product { Name = "Surf board", Price = 179 },
////new Product { Name = "Running shoes", Price = 95 }
////});
////            kernel.Bind<IProductsRepository>().ToConstant(mock.Object);

//            kernel.Bind<IProductsRepository>().To<EFProductRepository>();


//        }

        private void AddBindings()
        {
            kernel.Bind<IProductsRepository>().To<EFProductRepository>();
            EmailSettings emailSettings = new EmailSettings
            {
                WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"] ?? "true")
            };
            kernel.Bind<IOrderProcessor>().To<EmailOrderProcessor>().WithConstructorArgument("settings", emailSettings);
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}