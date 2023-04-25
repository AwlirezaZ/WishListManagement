using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishListManagement.Core.DbContext;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Services;

namespace WishListManagement.Controllers
{
    public class UserController : Controller
    {
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
            var id = _userService.Create(user);
            return RedirectToAction("UserInfo", new { id });
        }
        [Authorize]
        public ActionResult UserInfo(long id)
        {
            var userViewModel = _userService.GetUserById(id);
            if (userViewModel.Username != HttpContext.User.Identity.Name)
                throw new UnauthorizedAccessException("we are not allowed to show other users' information to you");
            return View(userViewModel);
        }
        [Authorize]
        public ActionResult EditUser(long id)
        {
            var userViewModel = _userService.GetUserById(id);
            if (userViewModel.Username != HttpContext.User.Identity.Name)
                throw new UnauthorizedAccessException("you are not allowed to show other users' information");
            return View(userViewModel);
        }
        [Authorize]
        [HttpPost]
        public ActionResult EditUser(ModifyUserViewModel user)
        {
            _userService.Modify(user);
            return RedirectToAction("UserInfo", new { id = user.Id });
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
                return RedirectToAction("UserInfo", new { id = user.Id });
            }
            return View(user);
        }


    }
}