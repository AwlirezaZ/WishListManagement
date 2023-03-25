using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using WishListManagement.Models.Domain.WishListItem;

namespace WishListManagement.Core.Mapping.WishList
{
    public class WishListMapping : EntityTypeConfiguration<Models.Domain.WishList.WishList>
    {
    public WishListMapping()
    {
        ToTable("WishLists").HasKey(a => a.Id)
            .Property(a => a.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        Property(a => a.Title).IsRequired();
        Property(a => a.Description).IsOptional();
        HasMany(a => a.WishListItems).WithRequired(a => a.WishList).HasForeignKey(a => a.WishListId);

        }
    }
}