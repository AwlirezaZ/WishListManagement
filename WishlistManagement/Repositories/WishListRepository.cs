using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WishListManagement.Core.DbContext;
using WishListManagement.Models.Domain.WishList;
using WishListManagement.Models.Domain.WishListItem;

namespace WishListManagement.Repositories
{
    public class WishListRepository
    {
        private readonly WishListManagementDbContext db;
        public WishListRepository()
        {
            db = new WishListManagementDbContext();
        }
        public long Create(WishList wishList)
        {
            db.WishLists.Add(wishList);
            db.SaveChanges();
            return wishList.Id;
        }

        public long Delete(long id)
        {
            var entity = GetSummaryById(id);
            db.WishLists.Remove(entity);
            db.SaveChanges();

            return entity.UserId;
        }

        public bool Update()
        {
            var wishListItems = db.ChangeTracker.Entries().Where(a =>
                a.State == EntityState.Modified).Select(a => a.Entity).OfType<WishListItem>().ToList();
            var deletedPackageHotel = wishListItems.Where(s => s.WishList == null).ToList();
            deletedPackageHotel.ForEach(a => db.WishListItems.Remove(a));
            db.SaveChanges();
            return true;
        }

        public WishList GetById(long id)
        {
            return db.FilteredWishLists
                .Include(a => a.User)
                .Include(a => a.WishListItems)
                .SingleOrDefault(a => a.Id == id);
        }
        public WishList GetSummaryById(long id)
        {
            return db.FilteredWishLists
                .SingleOrDefault(a => a.Id == id);
        }

        public List<WishList> GetWishListsByUserId()
        {
            return db.FilteredWishLists.ToList();
        }
    }
}