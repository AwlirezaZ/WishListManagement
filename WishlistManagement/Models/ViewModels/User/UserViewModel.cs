﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Models.ViewModels.User
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string BirthDate { get; set; }
    }
}