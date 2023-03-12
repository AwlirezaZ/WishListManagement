using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WishListManagement.Core.DbContext;
using WishListManagement.Models.Domain.User;

namespace WishListManagement.Repositories
{
    public class UserRepository
    {
        private readonly WishListManagementDbContext db;
        public UserRepository()
        {
            db = new WishListManagementDbContext();
        }

        public bool Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return true;
        }

        public User GetUserById(long id)
        {
            return db.Users.Find(id);
        }
    }
}