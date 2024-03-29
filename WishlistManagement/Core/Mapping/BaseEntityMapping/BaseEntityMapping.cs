﻿using System.Data.Entity.ModelConfiguration;
using WishListManagement.Models.Domain.BaseEntity;

namespace WishListManagement.Core.Mapping.BaseEntityMapping
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
