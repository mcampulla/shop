
using com.marcoelaura.shop.ViewModels;
using System;
using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class CategoryEditPage : ContentPage
    {
        CategoryEditViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public CategoryEditPage()
        {
            InitializeComponent();

            viewModel = new CategoryEditViewModel();
            viewModel.Item.Order = 1;

            BindingContext = viewModel;
        }

        public CategoryEditPage(CategoryEditViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            MessagingCenter.Send(this, "AddItem", viewModel.Item);
            await Navigation.PopToRootAsync();
        }
    }
}
