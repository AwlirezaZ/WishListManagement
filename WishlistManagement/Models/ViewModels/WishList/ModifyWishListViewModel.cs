using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Models.ViewModels.WishList
{
    public class ModifyWishListViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}