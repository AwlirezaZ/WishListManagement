using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Infrastructure.Mapping
{
    public class WishListMapping : EntityTypeConfiguration<WishList>
    {
        public WishListMapping()
        {
            Property(a => a.WishlistDescription).IsRequired();
            Property(a => a.Priority).IsOptional();
            Property(a => a.RoughPrice).IsOptional();
        }
    }
}
