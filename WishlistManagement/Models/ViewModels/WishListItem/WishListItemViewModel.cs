using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Models.ViewModels.WishList;

namespace WishListManagement.Models.ViewModels.WishListItem
{
    public class WishListItemViewModel
    {
        public long Id { get; set; }
        public string WishListItemDescription { get; set; }
        public decimal RoughPrice { get; set; }
        public int Priority { get; set; }
        public long WishListId { get; set; }
        public WishListViewModel WishList { get; set; }
    }
}