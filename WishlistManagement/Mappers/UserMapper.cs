using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Models.Domain.User;
using WishListManagement.Models.ViewModels.User;

namespace WishListManagement.Mappers
{
    public static class UserMapper
    {
        public static UserViewModel Map(User user)
        {
            return new UserViewModel()
            {
                Id = user.Id,
                Username = user.Username,
                Password = user.Password,
                BirthDate = user.BirthDate,
                Name = user.Name
            };
        }

        public static List<UserViewModel> Map(List<User> users)
        {
            return users?.Select(Map).ToList();
        }

    }
}