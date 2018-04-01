using System;
using System.Diagnostics;
using System.Threading.Tasks;

using com.marcoelaura.shop.Helpers;
using com.marcoelaura.shop.Models;
using com.marcoelaura.shop.Views;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace com.marcoelaura.shop.ViewModels
{
    public class CategoriesViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ShopCategory> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private IMobileServiceTable<ShopCategory> table;

        public CategoriesViewModel()
        {
            Title = "Manage Categories";
            Items = new ObservableRangeCollection<ShopCategory>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<CategoryEditPage, ShopCategory>(this, "AddItem", async (obj, item) =>
            {
                MessagingCenter.Unsubscribe<CategoryEditPage, ShopCategory>(this, "AddItem");

                var _item = item as ShopCategory;

                table = client.GetTable<ShopCategory>();
                try
                {
                    if (item.Id == null)
                        await table.InsertAsync(_item);
                    else
                        await table.UpdateAsync(_item);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }

                if (item.Id == null)
                    Items.Add(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await client.GetTable<ShopCategory>().ToListAsync();
                Items.Clear();
                Items.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "Alert");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}