using Microsoft.Azure.Mobile.Server;

namespace com.marcoelaura.shop.api.DataObjects
{
    public class ShopCategory : EntityData
    {
        public string Title { get; set; }

        public int Order { get; set; }
    }
}