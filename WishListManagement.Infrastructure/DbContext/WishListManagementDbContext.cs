using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Domain.BaseEntity;
using WishListManagement.Domain.User;
using WishListManagement.Domain.WishList;

namespace WishListManagement.Infrastructure.DbContext
{
    public class WishListManagementDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<WishListItem> WishList { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WishListManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
