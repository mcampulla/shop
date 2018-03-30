using Microsoft.Azure.Mobile.Server;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.marcoelaura.shop.api.DataObjects
{
    public class ShopItem : EntityData
    {
        public string Title { get; set; }

        public string CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public ShopCategory Category { get; set; }
    }
}