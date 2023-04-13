﻿using System;
using System.Collections.Generic;

namespace WishListManagement.Models.Domain.User
{
    public class User : BaseEntity.BaseEntity
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public DateTime? BirthDate { get; private set; }
        public List<WishList.WishList> WishLists { get; private set; }

        private User()
        {

        }
        public User(string username, string password, string name, DateTime? birthDate)
        {
            Username = username;
            Password = password;
            Name = name;
            BirthDate = birthDate;
            CreatedDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
        }
        public void Update(string username, string password, string name, DateTime? birthDate)
        {
            Username = username;
            Password = password;
            Name = name;
            BirthDate = birthDate;
            ModifiedDateTime = DateTime.Now;
        }

        public void UpdatePassword(string newPassword)
        {
            Password = newPassword;
        }
    }
}