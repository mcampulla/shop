using System;
using com.marcoelaura.shop.Helpers;
using com.marcoelaura.shop.Models;
using com.marcoelaura.shop.ViewModels;

using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class ListsPage : ContentPage
    {
        ListsViewModel viewModel;

        public ListsPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new ListsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ShopList;
            if (item == null)
                return;

            await Navigation.PushAsync(new ListEditPage(new ListEditViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListEditPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
