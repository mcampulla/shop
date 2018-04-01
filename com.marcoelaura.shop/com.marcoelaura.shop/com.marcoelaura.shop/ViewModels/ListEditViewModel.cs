using com.marcoelaura.shop.Models;
using System;

namespace com.marcoelaura.shop.ViewModels
{
    public class ListEditViewModel : BaseViewModel
    {
        public ShopList Item { get; set; }

        public ListEditViewModel(ShopList item = null)
        {
            if (item == null)
            {
                item = new ShopList();
                item.ListDate = DateTime.Today;
            }

            Title = item.Title;
            Item = item;
        }
    }
}