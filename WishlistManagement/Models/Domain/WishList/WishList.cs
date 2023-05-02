using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using WishListManagement.Models.ViewModels.WishListItem;

namespace WishListManagement.Models.Domain.WishList
{
    public class WishList :BaseEntity.BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<WishListItem.WishListItem> WishListItems { get; private set; }
        public User.User User { get; private set; }
        public long UserId { get; private set; }
        //public List<long> AllowedUserIds { get; set; }
        public WishList(string title, string description,long userId)
        {
            Title = title;
            Description = description;
            UserId = userId;
            CreatedDateTime = DateTime.Now;
            ModifiedDateTime = DateTime.Now;
        }
        private WishList()
        {
        }

        public void Update(string title, string description)
        {
            Title = title;
            Description = description;
            ModifiedDateTime = DateTime.Now;
        }

        public void UpdateItems(List<WishListItemViewModel> viewModelWishListItems)
        {
            throw new NotImplementedException();
        }
    }
}