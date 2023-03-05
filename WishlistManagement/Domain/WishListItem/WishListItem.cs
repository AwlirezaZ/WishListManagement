using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WishlistManagement.Domain.WishListItem
{
    public class WishListItem : BaseEntity.BaseEntity

    {
    public string WishListItemDescription { get; set; }
    public decimal RoughPrice { get; set; }
    public int Priority { get; set; }
    public User.User User { get; set; }
    public long UserId { get; set; }
    }
}