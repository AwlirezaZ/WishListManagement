using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Domain.WishList;

namespace WishListManagement.Infrastructure.Mapping.WishListMapping
{
    public class WishListMapping : EntityTypeConfiguration<WishListItem>
    {
        public WishListMapping()
        {
            ToTable("WishLists").HasKey(a => a.Id)
                .Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.WishListItemDescription).IsRequired();
            Property(a => a.Priority).IsOptional();
            Property(a => a.RoughPrice).IsOptional();
        }
    }
}
