using System.Data.Entity;
using WishListManagement.Models.Domain.BaseEntity;
using WishListManagement.Models.Domain.User;
using WishListManagement.Models.Domain.WishList;
using WishListManagement.Models.Domain.WishListItem;

namespace WishListManagement.Core.DbContext
{
    public class WishListManagementDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<WishListItem> WishListItems { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WishListManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
