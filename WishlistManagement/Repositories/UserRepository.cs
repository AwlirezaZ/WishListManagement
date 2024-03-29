﻿using System;
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

        public long Create(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.Id;
        }

        public User GetUserById(long id)
        {
            return db.Users.Find(id);
        }

        public bool Update(User user)
        {
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();

            return true;
        }
        public string GetPasswordByUsername(string username)
        {
            return db.Users.FirstOrDefault(a => a.Username == username)?.Password;
        }

        public User GetUserByUsername(string username)
        {
            return db.Users.FirstOrDefault(a => a.Username == username);
        }
    }
}