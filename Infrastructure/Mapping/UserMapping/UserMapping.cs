using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public UserMapping()
        {
            Property(a => a.Username).IsRequired();
            Property(a => a.Password).IsRequired();
            Property(a => a.Name).IsOptional();
            Property(a => a.BirthDate).IsOptional();
            HasMany(a => a.WishLists).WithRequired(a => a.User).HasForeignKey(a => a.UserId);
        }
    }
}
