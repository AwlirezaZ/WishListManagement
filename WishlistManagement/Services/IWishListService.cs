using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Models.ViewModels.WishList;

namespace WishListManagement.Services
{
    public interface IWishListService
    {
        long Create(CreateWishListViewModel viewModel);
        bool Edit(ModifyWishListViewModel viewModel);
        long Delete(long wishListId);
        WishListViewModel GetById(long wishListId);
        List<WishListViewModel> GetAllByUserId();
        bool UpdateWithItem(WishListViewModel viewModel);
    }
}
