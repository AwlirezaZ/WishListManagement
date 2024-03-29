﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Models.ViewModels.User
{
    public class ModifyUserViewModel
    {
        public long Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}