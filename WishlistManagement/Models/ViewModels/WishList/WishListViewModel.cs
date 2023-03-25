using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WishListManagement.Models.ViewModels.User;
using WishListManagement.Models.ViewModels.WishListItem;

namespace WishListManagement.Models.ViewModels.WishList
{
    public class WishListViewModel
    {
        public long Id { get; set; }
        public string Title { get;  set; }
        public string Description { get;  set; }
        public List<WishListItemViewModel> WishListItems { get; set; }
        public UserViewModel User { get; set; }
        public long UserId { get; set; }
    }
}