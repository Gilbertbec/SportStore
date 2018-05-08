namespace Vic.SportsStore.WebApp
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Vic.SportsStore.Domain.Entities;
    using Vic.SportsStore.WebApp.Infrastructure.Binders;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            ModelBinders.Binders.Add(typeof(Cart), new CartModelBinder());
        }
    }
}
