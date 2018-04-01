
using com.marcoelaura.shop.ViewModels;
using System;
using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class ItemEditPage : ContentPage
    {
        ItemEditViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ItemEditPage()
        {
            InitializeComponent();

            viewModel = new ItemEditViewModel();

            BindingContext = viewModel;
        }

        public ItemEditPage(ItemEditViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Categories.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            //MessagingCenter.Send(this, "AddItem", viewModel.Item);
            await viewModel.Save();

            await Navigation.PopToRootAsync();
        }
    }
}
