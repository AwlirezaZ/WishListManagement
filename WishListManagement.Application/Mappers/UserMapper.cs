using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Application.Contracts.User.ViewModels;

namespace WishListManagement.Application.Mappers
{
    public static class UserMapper
    {
        public static List<UserViewModel> Map(List<Domain.User.User> users)
        {
            return users.Select(Map).ToList();
        }

        public static UserViewModel Map(Domain.User.User user)
        {
            return new UserViewModel()
            {
                Username = user.Username,
                Password = user.Password,
                Name = user.Name,
                BirthDate = user.BirthDate
            };
        }
    }
}
