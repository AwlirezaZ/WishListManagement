using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WishListManagement.Models.ViewModels.User
{
    public class ChangePasswordUserViewModel
    {
        public long Id { get; set; }
        [DataType("Password")]
        public string OldPassword { get; set; }
        [DataType("Password")]
        public string NewPassword { get; set; }
        [DataType("Password")]
        [Compare("NewPassword", ErrorMessage = "The password and confirmation password do not match.")]
        public string NewPasswordConfirmation { get; set; }
    }
}