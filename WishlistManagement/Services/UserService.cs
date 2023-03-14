using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Mappers;
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

        public long Create(CreateUserViewModel viewModel)
        {
            var user = new User(viewModel.Username, viewModel.Password, viewModel.Name, viewModel.BirthDate);
            return _userRepository.Create(user);
        }

        public UserViewModel GetUserById(long id)
        {
            var user = _userRepository.GetUserById(id);
            return UserMapper.Map(user);
        }

        public bool Modify(ModifyUserViewModel modifyUserViewModel)
        {
            var user = _userRepository.GetUserById(modifyUserViewModel.Id);
            user.Update(modifyUserViewModel.Username,modifyUserViewModel.Password,modifyUserViewModel.Name,modifyUserViewModel.BirthDate);
            _userRepository.Update(user);
            return true;
        }
    }
}