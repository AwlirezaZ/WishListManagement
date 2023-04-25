using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
            var hashedPassword = HashAndSaltPasswords(viewModel.Password);
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
            var hashedNewPassword = HashAndSaltPasswords(userViewModel.NewPassword);
            user.UpdatePassword(hashedNewPassword);
            return _userRepository.Update(user);
        }

        private void CheckOldPasswordMatch(string oldPassword, string hashedSavedOldPassword)
        {
            if (!UserIsRegistered(hashedSavedOldPassword,oldPassword))
                throw new Exception();
        }

        public string GetPasswordByUsername(string username)
        {
            return _userRepository.GetPasswordByUsername(username);
        }

        public UserViewModel GetUserByUsername(string username)
        {
            var user = _userRepository.GetUserByUsername(username);
            return UserMapper.Map(user);
        }
        public bool UserIsRegistered(string savedPassword, string inputPassword)
        {
            byte[] hashBytes = Convert.FromBase64String(savedPassword);
            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);
            var pbkdf2 = new Rfc2898DeriveBytes(inputPassword, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            for (int i = 0; i < 20; i++)
                if (hashBytes[i + 16] != hash[i]) return false;
            return true;
        }
        public string HashAndSaltPasswords(string password)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);
            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }
    }
}