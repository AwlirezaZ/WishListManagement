using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.SessionState;
using WishListManagement.Application.Contracts.User.Service;
using WishListManagement.Application.User;
using WishListManagement.Controllers;

namespace WishlistManagement.Controllers
{
    public class WishListControllerFactory : IControllerFactory
    {
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            IUserService userService = new UserService();
            var controller = new UserController(userService);
            return controller;
        }

        public SessionStateBehavior GetControllerSessionBehavior(RequestContext requestContext, string controllerName)
        {
            return SessionStateBehavior.Default;
        }

        public void ReleaseController(IController controller)
        {
            if (controller is IDisposable disposable)
                disposable.Dispose();
        }
    }
}