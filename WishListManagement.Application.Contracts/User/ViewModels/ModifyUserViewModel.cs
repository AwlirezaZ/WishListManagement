﻿using System;

namespace WishListManagement.Application.Contracts.User.ViewModels
{
    public class ModifyUserViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}