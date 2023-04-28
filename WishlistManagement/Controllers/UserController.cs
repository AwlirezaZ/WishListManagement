using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishListManagement.Core.DbContext;
using WishListManagement.Helpers;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Services;

namespace WishListManagement.Controllers
{
    public class UserController : Controller
    {
        //private readonly IUserService _userService;
        //public UserController(IUserService userService)
        //{
        //    _userService = userService;
        //}

        private readonly UserService _userService;
        public UserController()
        {
            _userService = new UserService();
        }


        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel user)
        {
            _userService.Create(user);
            return RedirectToAction("UserInfo");
        }
        [Authorize]
        public ActionResult UserInfo()
        {
            var userId = AuthenticationHelper.GetLoggedInUserId();
            var userViewModel = _userService.GetUserById(userId);
            return View(userViewModel);
        }
        [Authorize]
        public ActionResult EditUser()
        {
            var userId = AuthenticationHelper.GetLoggedInUserId();
            var userViewModel = _userService.GetUserById(userId);
            return View(userViewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditUser(ModifyUserViewModel user)
        {
            _userService.Modify(user);
            return RedirectToAction("UserInfo");
        }

        [Authorize]
        public ActionResult ChangePassword(UserViewModel user)
        {
            if (user == null) throw new ArgumentNullException();
            var changePassViewModel = new ChangePasswordUserViewModel() { Id = user.Id, OldPassword = user.Password, NewPassword = " " };
            return View(changePassViewModel);
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                if (user == null) throw new ArgumentNullException();
                _userService.UpdatePassword(user);
                return RedirectToAction("UserInfo");
            }
            return View(user);
        }


    }
}