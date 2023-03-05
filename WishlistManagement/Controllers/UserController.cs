using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            _userService.Create
            return View();

        }


    }
}