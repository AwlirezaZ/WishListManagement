using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using WishListManagement.Models.Domain.WishListItem;
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
                Priority = wishListItem.Priority,
                RoughPrice = wishListItem.RoughPrice,
                User = UserMapper.Map(wishListItem.User),
                UserId = wishListItem.UserId
            };
        }

        public static List<WishListItemViewModel> Map(List<WishListItem> wishListItems)
        {
            return wishListItems.Select(Map).ToList();
        }
    }
}