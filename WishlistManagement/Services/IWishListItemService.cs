using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Models.ViewModels.WishList;
using WishListManagement.Models.ViewModels.WishListItem;

namespace WishListManagement.Services
{
    public interface IWishListItemService
    {
        long CreateWishListItem(CreateWishListItemViewModel createViewModel);
        WishListItemViewModel GetWishListItemById(long id);
        long DeleteWishListItem(long id);
        bool ModifyWishListItem(ModifyWishListItemViewModel modifyViewModel);
        List<WishListItemViewModel> GetWishListItemsByUserId(long wishListId);
    }
}
