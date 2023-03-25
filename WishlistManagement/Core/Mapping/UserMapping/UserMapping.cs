using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WishListManagement.Models.Domain.User;

namespace WishListManagement.Core.Mapping.UserMapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            ToTable("Users").HasKey(a => a.Id)
                .Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Username).IsRequired();
            Property(a => a.Password).IsRequired();
            Property(a => a.Name).IsOptional();
            Property(a => a.BirthDate).IsOptional();
            HasMany(a => a.WishLists).WithRequired(a => a.User).HasForeignKey(a => a.UserId);
        }
    }
}
