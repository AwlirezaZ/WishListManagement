using System.Data.Entity;
using Domain;

namespace Infrastructure.DbContext
{
    public class WishListManagementDbContext : System.Data.Entity.DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<BaseEntity> BaseEntities { get; set; }
        public DbSet<WishList> WishLists { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(WishListManagementDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
