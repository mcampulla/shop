using Microsoft.Azure.Mobile.Server;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.marcoelaura.shop.api.DataObjects
{
    public class ShopList : EntityData
    {
        public string Title { get; set; }

        public DateTime ListDate { get; set; }

        public ICollection<ShopListItem> Items { get; set; }
    }
}