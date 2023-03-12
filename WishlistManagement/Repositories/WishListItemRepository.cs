using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WishListManagement.Core.DbContext;
using WishListManagement.Models.Domain.WishListItem;

namespace WishListManagement.Repositories
{
    public class WishListItemRepository
    {
        private readonly WishListManagementDbContext db;
        public WishListItemRepository()
        {
            db = new WishListManagementDbContext();
        }

        public bool Create(WishListItem wishListItem)
        {
            db.WishListItems.Add(wishListItem);
            return true;
        }

        public bool Delete(long id)
        {
             db.WishListItems.Remove(GetById(id));
             return true;
        }

        public bool Update(WishListItem wishListItem)
        {
            db.Entry(wishListItem).State = EntityState.Modified;
            return true;
        }

        public WishListItem GetById(long id)
        {
            return db.WishListItems.Find(id);
        }

        public List<WishListItem> GetWishListItemsByUserId(long userId)
        {
            return db.WishListItems.Where(a => a.UserId == userId).ToList();
        }

    }
}