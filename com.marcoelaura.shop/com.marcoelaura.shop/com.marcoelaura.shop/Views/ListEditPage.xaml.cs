
using com.marcoelaura.shop.ViewModels;
using System;
using Xamarin.Forms;

namespace com.marcoelaura.shop.Views
{
    public partial class ListEditPage : ContentPage
    {
        ListEditViewModel viewModel;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public ListEditPage()
        {
            InitializeComponent();

            viewModel = new ListEditViewModel();

            BindingContext = viewModel;
        }

        public ListEditPage(ListEditViewModel viewModel)
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
