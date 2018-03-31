namespace com.marcoelaura.shop.Models
{
    public class ShopListItem : BaseObject
    {
        public string ShopItemId { get; set; }

        public ShopItem ShopItem { get; set; }

        public int Quantity { get; set; }

        public bool Complete { get; set; }
    }
}