using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using WishListManagement.Services;

namespace WishListManagement.Core.Config
{
    public class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserService>().As<IUserService>();
            return builder.Build();
        }
    }
}