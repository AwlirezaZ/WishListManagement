using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Models.ViewModels.WishListItem
{
    public class CreateWishListItemViewModel
    {
        public string WishListItemDescription { get; set; }
        public decimal RoughPrice { get; set; }
        public int Priority { get; set; }
        public long UserId { get; set; }
    }
}