using System.Collections.Generic;

namespace WishListManagement.Models.Domain.WishList
{
    public class WishList :BaseEntity.BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public List<WishListItem.WishListItem> WishListItems { get; set; }
        public User.User User { get; set; }
        public long UserId { get; set; }
        //public List<long> AllowedUserIds { get; set; }
    }
}