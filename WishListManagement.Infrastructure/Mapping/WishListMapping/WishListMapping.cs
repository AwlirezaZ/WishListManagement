using System;
using System.Collections.Generic;
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
            Property(a => a.WishListItemDescription).IsRequired();
            Property(a => a.Priority).IsOptional();
            Property(a => a.RoughPrice).IsOptional();
        }
    }
}
