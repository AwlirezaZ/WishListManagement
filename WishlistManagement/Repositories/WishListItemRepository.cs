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

        public long Create(WishListItem wishListItem)
        {
            db.WishListItems.Add(wishListItem);
            db.SaveChanges();

            return wishListItem.Id;
        }

        public long Delete(long id)
        {
            var entity = GetById(id);
             db.WishListItems.Remove(entity);
             db.SaveChanges();

            return entity.UserId;
        }

        public bool Update(WishListItem wishListItem)
        {
            db.Entry(wishListItem).State = EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public WishListItem GetById(long id)
        {
            return db.WishListItems.Include(a => a.User).SingleOrDefault(a => a.Id ==id);
        }

        public List<WishListItem> GetWishListItemsByUserId(long userId)
        {
            return db.WishListItems.Where(a => a.UserId == userId).ToList();
        }

    }
}