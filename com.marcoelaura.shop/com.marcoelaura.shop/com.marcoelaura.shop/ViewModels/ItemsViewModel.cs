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
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ShopList> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private IMobileServiceTable<ShopList> shopListTable;

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableRangeCollection<ShopList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, ShopList>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as ShopList;

                shopListTable = client.GetTable<ShopList>();
                try
                {
                    await shopListTable.InsertAsync(_item);
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                }
                                
                Items.Add(_item);
                //await DataStore.AddItemAsync(_item);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await client.GetTable<ShopList>().ToListAsync();

                Items.Clear();
                //var items = await DataStore.GetItemsAsync(true);
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