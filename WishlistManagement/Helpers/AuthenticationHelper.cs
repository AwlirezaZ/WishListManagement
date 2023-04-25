using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Helpers
{
    public static class AuthenticationHelper
    {
        public static long GetLoggedInUserId()
        {
            return Int64.Parse(HttpContext.Current.User.Identity.Name.Split(',')[0]);
        }

        public static string GetLoggedInUser()
        {
            return HttpContext.Current.User.Identity.Name.Split(',')[1];
        }

        public static bool IsUserLoggedIn()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }
    }
}