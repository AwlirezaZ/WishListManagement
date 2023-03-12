namespace WishListManagement.Models.ViewModels.WishListItem
{
    public class ModifyWishListItemViewModel
    {
        public long Id { get; set; }
        public string WishListItemDescription { get; set; }
        public decimal RoughPrice { get; set; }
        public int Priority { get; set; }
        public long UserId { get; set; }
    }
}