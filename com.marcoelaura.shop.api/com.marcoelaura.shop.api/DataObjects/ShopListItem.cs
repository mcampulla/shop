﻿using Microsoft.Azure.Mobile.Server;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.marcoelaura.shop.api.DataObjects
{
    public class ShopListItem : EntityData
    {
        public string ShopListId { get; set; }

        [ForeignKey("ShopListId")]
        public ShopList ShopList { get; set; }

        public string ShopItemId { get; set; }

        [ForeignKey("ShopItemId")]
        public ShopItem ShopItem { get; set; }

        public int Quantity { get; set; }

        public bool Completed { get; set; }
    }
}