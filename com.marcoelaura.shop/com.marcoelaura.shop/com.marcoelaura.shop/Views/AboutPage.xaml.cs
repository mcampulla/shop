
using System;
using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void ManageItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemsPage());
        }

        async void ManageCategory_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoriesPage());
        }

        async void ManageList_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListsPage());
        }
    }
}
