using Microsoft.Azure.Mobile.Server;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.marcoelaura.shop.api.DataObjects
{
    public class ShopListItem : EntityData
    {
        public string ShopItemId { get; set; }

        [ForeignKey("ShopItemId")]
        public ShopItem ShopItem { get; set; }

        public int Quantity { get; set; }

        public bool Complete { get; set; }
    }
}