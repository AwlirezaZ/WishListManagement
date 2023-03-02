using System;
using System.Collections.Generic;

namespace WishListManagement.Domain.User
{
    public class User : BaseEntity.BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
        public List<WishList.WishListItem> WishList { get; set; }
    }
}
