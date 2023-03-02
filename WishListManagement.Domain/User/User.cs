using System;
using System.Collections.Generic;

namespace WishListManagement.Domain.User
{
    public class User : BaseEntity.BaseEntity
    {
        public User(string username, string password, string name, DateTime? birthDate)
        {
            Username = username;
            Password = password;
            Name = name;
            BirthDate = birthDate;
        }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public List<WishList.WishListItem> WishList { get; private set; }

    }
}
