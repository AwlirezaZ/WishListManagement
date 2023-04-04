using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Services;

namespace WishListManagement.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserService _service;
        public AuthenticationController()
        {
            _service = new UserService();
        }
        // GET: Authentication
         

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginUserViewModel user, string returnUrl)
        {
            var savedUser = _service.GetUserByUsername(user.Username);
            var userIsRegistered = _service.UserIsRegistered(savedUser.Password, user.Password);
            if (userIsRegistered)
                FormsAuthentication.SetAuthCookie(user.Username, false);
            if (returnUrl != null) return Redirect(returnUrl);
            return RedirectToAction("UserInfo", "User", new { id = savedUser.Id });
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }
    }
}