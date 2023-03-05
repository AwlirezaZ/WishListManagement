using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Models.Domain.User;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Repositories;

namespace WishListManagement.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public bool Create(CreateUserViewModel viewModel)
        {
            var user = new User(viewModel.Username, viewModel.Password, viewModel.Name, viewModel.BirthDate);
            return _userRepository.Create(user);
        }
    }
}