namespace com.marcoelaura.shop.Models
{
    public class ShopListItem : BaseObject
    {
        public string ShopListId { get; set; }

        public ShopList ShopList { get; set; }

        public string ShopItemId { get; set; }

        public ShopItem ShopItem { get; set; }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { SetProperty(ref quantity, value); }
        }

        public bool Complete { get; set; }
    }
}