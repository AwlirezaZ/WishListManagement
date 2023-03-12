namespace WishListManagement.Models.Domain.WishListItem
{
    public class WishListItem : BaseEntity.BaseEntity

    {
        public WishListItem(string wishListItemDescription, decimal roughPrice, int priority, long userId)
        {
            WishListItemDescription = wishListItemDescription;
            RoughPrice = roughPrice;
            Priority = priority;
            UserId = userId;
        }
        public string WishListItemDescription { get; private set; }
        public decimal RoughPrice { get; private set; }
        public int Priority { get; private set; }
        public User.User User { get; private set; }
        public long UserId { get; private set; }

        public void Update(string wishListItemDescription, decimal roughPrice, int priority)
        {
            WishListItemDescription = wishListItemDescription;
            RoughPrice = roughPrice;
            Priority = priority;
        }
    }
}