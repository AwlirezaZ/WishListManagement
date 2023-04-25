using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
        public static string HashAndSaltPasswords(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
        public static bool UserIsRegistered(string savedPassword, string inputPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i]) return false;
            return true;
        }
    }
}