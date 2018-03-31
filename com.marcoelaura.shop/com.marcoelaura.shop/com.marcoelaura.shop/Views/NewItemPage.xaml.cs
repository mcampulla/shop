using System;

using com.marcoelaura.shop.Models;

using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class NewItemPage : ContentPage
    {
        public ShopList Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new ShopList
            {
                Title = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                ListDate = DateTime.Now
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopToRootAsync();
            //await Navigation.PushAsync(new ItemsPage());
        }
    }
}