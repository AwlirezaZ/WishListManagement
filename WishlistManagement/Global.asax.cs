using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WishlistManagement.Controllers;

namespace WishListManagement
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterCustomControllerFactory();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        private void RegisterCustomControllerFactory()
        {
            IControllerFactory factory = new WishListControllerFactory();
            ControllerBuilder.Current.SetControllerFactory(factory);
        }
    }
}
