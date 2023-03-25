using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Models.ViewModels.WishList
{
    public class CreateWishListViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long UserId { get; set; }

    }
}