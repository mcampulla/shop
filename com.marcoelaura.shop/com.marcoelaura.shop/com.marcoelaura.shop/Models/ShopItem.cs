namespace com.marcoelaura.shop.Models
{
    public class ShopItem : BaseObject
    {
        public string Title { get; set; }

        public string CategoryId { get; set; }

        public ShopCategory Category { get; set; }
    }
}