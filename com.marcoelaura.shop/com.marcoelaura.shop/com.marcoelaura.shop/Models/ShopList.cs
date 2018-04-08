using com.marcoelaura.shop.Helpers;
using System;
using System.Collections.Generic;

namespace com.marcoelaura.shop.Models
{
    public class ShopList : BaseObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private DateTime listDate;
        public DateTime ListDate
        {
            get { return listDate; }
            set { SetProperty(ref listDate, value); }
        }

        private bool completed;
        public bool Completed
        {
            get { return completed; }
            set { SetProperty(ref completed, value); }
        }

        public ICollection<ShopListItem> Items { get; set; }
    }
}