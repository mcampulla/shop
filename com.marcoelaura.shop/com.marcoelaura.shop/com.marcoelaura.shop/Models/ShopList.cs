using System;

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
    }
}