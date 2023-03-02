using System;
using System.Collections.Generic;

namespace WishListManagement.Domain.User
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<WishList.WishList> WishLists { get; set; }
    }
}
