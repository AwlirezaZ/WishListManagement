using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WishListManagement.Controllers
{
    public class UserController : Controller
    {

        public UserController()
        {
            
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
        public ActionResult CreateUser(string x )
        {
            return View();

        }


    }
}