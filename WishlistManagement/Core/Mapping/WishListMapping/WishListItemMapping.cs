using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using WishListManagement.Models.Domain.WishListItem;

namespace WishListManagement.Core.Mapping.WishListMapping
{
    public class WishListItemMapping : EntityTypeConfiguration<WishListItem>
    {
        public WishListItemMapping()
        {
            ToTable("WishListItems").HasKey(a => a.Id)
                .Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(a => a.Title).IsRequired();
            Property(a => a.Priority).IsOptional();
            Property(a => a.RoughPrice).IsOptional();
        }
    }
}
