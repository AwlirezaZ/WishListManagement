using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WishListManagement.Application.Contracts.User.Service
{
    public interface IUserService
    {
        bool CreateUser(object user);
        object GetUserById(long id);
        bool DeleteUser(long id);
        bool ModifyUser(object user);
    }
}
