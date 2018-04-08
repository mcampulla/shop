using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

using com.marcoelaura.shop.Helpers;
using com.marcoelaura.shop.Models;
using com.marcoelaura.shop.Views;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace com.marcoelaura.shop.ViewModels
{
    public class ListsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<ShopList> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        private IMobileServiceTable<ShopList> table;

        public ListsViewModel()
        {
            Title = "Manage List";
            Items = new ObservableRangeCollection<ShopList>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<ListEditPage, ShopList>(this, "AddItem", async (obj, item) =>
            {
                MessagingCenter.Unsubscribe<ListEditPage, ShopList>(this, "AddItem");

                var _item = item as ShopList;

                table = client.GetTable<ShopList>();
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
                //IMobileServiceTable table = client.GetTable("ShopList");
                //JToken untypedItems = await table.ReadAsync("$expand=Items");
                //var a = JsonConvert.DeserializeObject<ShopList>(untypedItems.First.ToString());
                //$expand = ShopItem,ShopList &$filter = ShopListId eq '23214d09a38a42feaf3f2c71c1d81191'

                //var test = await client.GetTable<ShopListItem>()
                //    //.ReadAsync("$expand=ShopItem,ShopList&$filter=ShopListId eq '23214d09a38a42feaf3f2c71c1d81191'");
                //.ReadAsync("expand=ShopItem,ShopList");
                //.WithParameters(new Dictionary<string, string> { { "expand", "Items" },
                //    { "$filter", "ShopListId eq '23214d09a38a42feaf3f2c71c1d81191'"}
                //})
                //.ToListAsync();

                var items = await client.GetTable<ShopList>().ToListAsync();
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