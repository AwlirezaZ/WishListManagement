using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Domain.User;
using WishListManagement.Infrastructure.DbContext;

namespace WishListManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly WishListManagementDbContext _context;

        public UserRepository(WishListManagementDbContext context)
        {
            _context = context;
        }

        public bool Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return true;
        }

        public User GetUserById(long id)
        {
            return _context.Users.Find(id);
        }

        public bool Delete(long id)
        {
            var user = GetUserById(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return true;
        }

        public bool Modify(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
            return true;
        }

        public List<User> GetUsersList()
        {
            return _context.Users.ToList();
        }
    }
}
