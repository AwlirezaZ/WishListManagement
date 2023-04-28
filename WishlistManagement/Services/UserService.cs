using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using WishListManagement.Helpers;
using WishListManagement.Mappers;
using WishListManagement.Models.Domain.User;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Repositories;

namespace WishListManagement.Services
{
    public class UserService : IUserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public long Create(CreateUserViewModel viewModel)
        {
            var hashedPassword =  AuthenticationHelper.HashAndSaltPasswords(viewModel.Password);
            var user = new User(viewModel.Username, hashedPassword, viewModel.Name, viewModel.BirthDate);
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

        public bool UpdatePassword(ChangePasswordUserViewModel userViewModel)
        {
            var user = _userRepository.GetUserById(userViewModel.Id);
            CheckOldPasswordMatch(userViewModel.OldPassword,user.Password);
            var hashedNewPassword = AuthenticationHelper.HashAndSaltPasswords(userViewModel.NewPassword);
            user.UpdatePassword(hashedNewPassword);
            return _userRepository.Update(user);
        }

        private void CheckOldPasswordMatch(string oldPassword, string hashedSavedOldPassword)
        {
            if (!AuthenticationHelper.UserIsRegistered(hashedSavedOldPassword,oldPassword))
                throw new Exception();
        }

        public UserViewModel GetUserByUsername(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            return UserMapper.Map(user);
        }
       
        
    }
}