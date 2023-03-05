using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishListManagement.Domain.BaseEntity
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }
}