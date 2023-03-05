using System;

namespace WishListManagement.Models.Domain.BaseEntity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}