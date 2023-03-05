using System.Data.Entity;
using WishListManagement.Domain.BaseEntity;
using WishListManagement.Domain.User;
using WishListManagement.Domain.WishListItem;

namespace WishlistManagement.Core.DbContext
{
    public class WishListManagementDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WishListManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
