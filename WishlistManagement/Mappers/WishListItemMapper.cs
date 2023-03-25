using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WishListManagement.Models.Domain.WishListItem;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Models.ViewModels.WishList;
using WishListManagement.Models.ViewModels.WishListItem;

namespace WishListManagement.Mappers
{
    public static class WishListItemMapper
    {
        public static WishListItemViewModel Map(WishListItem wishListItem)
        {
            return new WishListItemViewModel()
            {

                Id = wishListItem.Id,
                WishListItemDescription = wishListItem.Title,
                Priority = wishListItem.Priority,
                RoughPrice = wishListItem.RoughPrice,
                WishList =  wishListItem.WishList != null? WishListMapper.Map(wishListItem.WishList):new WishListViewModel(),
                WishListId = wishListItem.WishListId
            };
        }

        public static List<WishListItemViewModel> Map(List<WishListItem> wishListItems)
        {
            return wishListItems.Select(Map).ToList();
        }
    }
}