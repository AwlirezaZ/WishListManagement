using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Domain.User;

namespace WishListManagement.Infrastructure.Mapping.UserMapping
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
            HasMany(a => a.WishList).WithRequired(a => a.User).HasForeignKey(a => a.UserId);
        }
    }
}
