using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Models.Domain.WishList;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Models.ViewModels.WishList;
using WishListManagement.Models.ViewModels.WishListItem;

namespace WishListManagement.Mappers
{
    public static class WishListMapper
    {

        public static WishListViewModel Map(WishList wishList)
        {
            return new WishListViewModel()
            {
                Id = wishList.Id,
                Description = wishList.Description,
                Title = wishList.Title,
                User = wishList.User != null ? UserMapper.Map(wishList.User) : new UserViewModel(),
                UserId = wishList.Id,
                WishListItems = wishList.WishListItems != null
                    ? WishListItemMapper.Map(wishList.WishListItems)
                    : new List<WishListItemViewModel>()
            };
        }

        public static List<WishListViewModel> Map(List<WishList> wishLists)
        {
            return wishLists.Select(Map).ToList();
        }
    }
}