using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WishListManagement.Controllers;
using WishListManagement.Services;

namespace WishListManagement.Core.Config
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<WishListService>().As<IWishListService>();
            builder.RegisterType<WishListItemService>().As<IWishListItemService>();
            
            builder.RegisterType<UserController>().InstancePerRequest();
            builder.RegisterType<WishListController>().InstancePerRequest();
            builder.RegisterType<WishListItemController>().InstancePerRequest();
            builder.RegisterType<AuthenticationController>().InstancePerRequest();

            var container= builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            return container;
        }
    }
}