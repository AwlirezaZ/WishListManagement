using WishListManagement.Domain.User;

namespace WishListManagement.Domain.WishList
{
    public class WishList : BaseEntity.BaseEntity
    {
        public string WishlistDescription { get; set; }
        public decimal RoughPrice { get; set; }
        public int Priority { get; set; }
        public User.User User { get; set; }
        public int UserId { get; set; }
    }
}
