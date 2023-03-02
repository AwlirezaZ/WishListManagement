using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WishListManagement.Application.Contracts.User.Service;
using WishListManagement.Application.Contracts.User.ViewModels;

namespace WishListManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _userService.GetUsersList();
            return View(User);
        }

        [HttpPost]
        public ActionResult CreateUser(CreateUserViewModel viewModel)
        {
            return View();

        }


    }
}