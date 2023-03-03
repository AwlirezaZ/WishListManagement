using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Application.Contracts.User.Service;
using WishListManagement.Application.Contracts.User.ViewModels;
using WishListManagement.Application.Mappers;
using WishListManagement.Domain.User;

namespace WishListManagement.Application.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService()
        {
            
        }
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool CreateUser(CreateUserViewModel user)
        {
            var newUser = new Domain.User.User(user.Username, user.Password, user.Name, user.BirthDate);
            _userRepository.Create(newUser);
            return true;
        }

        public UserViewModel GetUserById(long id)
        {
            var user = _userRepository.GetUserById(id);
            return new UserViewModel();
        }

        public bool DeleteUser(long id)
        {
            _userRepository.Delete(id);
            return true;
        }

        public bool ModifyUser(ModifyUserViewModel user)
        {
            var newUser = new Domain.User.User(user.Username, user.Password, user.Name, user.BirthDate);
            _userRepository.Modify(newUser);
            return true;
        }

        public List<UserViewModel> GetUsersList()
        {
            var users = _userRepository.GetUsersList();
            return UserMapper.Map(users);
        }
    }
}
