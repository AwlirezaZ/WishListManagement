using WishListManagement.Models.ViewModels.User;

namespace WishListManagement.Services
{
    public interface IUserService
    {
        long Create(CreateUserViewModel viewModel);
        UserViewModel GetUserById(long id);
        bool Modify(ModifyUserViewModel modifyUserViewModel);
        bool UpdatePassword(ChangePasswordUserViewModel userViewModel);
        UserViewModel GetUserByUsername(string username);
    }
}