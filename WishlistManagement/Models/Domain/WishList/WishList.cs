using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using WishListManagement.Models.ViewModels.WishListItem;

namespace WishListManagement.Models.Domain.WishList
{
    public class WishList : BaseEntity.BaseEntity
    {
        public string Title { get; private set; }
        public string Description { get; private set; }
        public List<WishListItem.WishListItem> WishListItems { get; private set; }
        public User.User User { get; private set; }
        public long UserId { get; private set; }
        //public List<long> AllowedUserIds { get; set; }
        public WishList(string title, string description, long userId)
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

        public void UpdateItems(List<WishListItem.WishListItem> wishListItems)
        {
            AddNewWishListItems(wishListItems);
            RemoveDeletedWishListItems(wishListItems);
            ModifyUpdatedWishListItems(wishListItems);
        }

        private void ModifyUpdatedWishListItems(List<WishListItem.WishListItem> wishListItems)
        {
            var existedItems = wishListItems.Where(w => w.Id != 0).ToList();
            foreach (var wishListItem in existedItems)
            {
                var existedItem = this.WishListItems.FirstOrDefault(w => w.Id == wishListItem.Id);
                if (existedItem == null) continue;
                existedItem.Update(wishListItem.Title, wishListItem.RoughPrice, wishListItem.Priority);
            }

        }
        private void AddNewWishListItems(List<WishListItem.WishListItem> wishListItems)
        {
            var addedItems = wishListItems.Where(w => w.Id == 0).ToList();
            WishListItems.AddRange(addedItems);
        }


        public void RemoveDeletedWishListItems(List<WishListItem.WishListItem> wishListItems)
        {
            var existingIds = this.WishListItems.Select(z => z.Id).ToList();
            var wishListItemsIds = wishListItems.Select(a => a.Id).ToList();

            var removedIds = existingIds.Except(wishListItemsIds).ToList();
            this.WishListItems.RemoveAll(a => removedIds.Contains(a.Id));
        }
    }
}