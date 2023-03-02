using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Application.Contracts.User.ViewModels;

namespace WishListManagement.Application.Contracts.User.Service
{
    public interface IUserService
    {
        bool CreateUser(CreateUserViewModel user);
        UserViewModel GetUserById(long id);
        bool DeleteUser(long id);
        bool ModifyUser(ModifyUserViewModel user);
    }
}
