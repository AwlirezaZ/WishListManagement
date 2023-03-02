using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WishListManagement.Domain.BaseEntity;

namespace WishListManagement.Infrastructure.Mapping.BaseEntityMapping
{
    public class BaseEntityMapping : EntityTypeConfiguration<BaseEntity>
    {
        public BaseEntityMapping()
        {
            HasKey(a => a.Id);
            Property(a => a.CreatedDateTime).IsRequired();
            Property(a => a.ModifiedDateTime).IsRequired();
        }
    }
}
