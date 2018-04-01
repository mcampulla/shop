using System;
using com.marcoelaura.shop.Helpers;
using com.marcoelaura.shop.Models;
using com.marcoelaura.shop.ViewModels;

using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class CategoriesPage : ContentPage
    {
        CategoriesViewModel viewModel;

        public CategoriesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new CategoriesViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as ShopCategory;
            if (item == null)
                return;

            await Navigation.PushAsync(new CategoryEditPage(new CategoryEditViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new CategoryEditPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Items.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
