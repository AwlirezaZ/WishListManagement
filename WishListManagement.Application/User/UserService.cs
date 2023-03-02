using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Application.Contracts.User.Service;
using WishListManagement.Domain.User;

namespace WishListManagement.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(object user)
        {
            
        }

        public object GetUserById(long id)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(long id)
        {
            throw new NotImplementedException();
        }

        public bool ModifyUser(object user)
        {
            throw new NotImplementedException();
        }
    }
}
