using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using com.marcoelaura.shop.Models;

using Xamarin.Forms;

[assembly: Dependency(typeof(com.marcoelaura.shop.Services.MockDataStore))]
namespace com.marcoelaura.shop.Services
{
    public class MockDataStore : IDataStore<ShopList>
    {
        bool isInitialized;
        List<ShopList> items;

        public async Task<bool> AddItemAsync(ShopList item)
        {
            await InitializeAsync();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(ShopList item)
        {
            await InitializeAsync();

            var _item = items.Where((ShopList arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(ShopList item)
        {
            await InitializeAsync();

            var _item = items.Where((ShopList arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<ShopList> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<ShopList>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(items);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            await Task.Run(() =>
            {
                items = new List<ShopList>();
                var _items = new List<ShopList>
                {
            new ShopList { Id = Guid.NewGuid().ToString(), Title = "Buy some cat food", ListDate=DateTime.Today},
            new ShopList { Id = Guid.NewGuid().ToString(), Title = "Learn F#", ListDate=DateTime.Today.AddDays(-7)},
                };

                foreach (ShopList item in _items)
                {
                    items.Add(item);
                }
            });

            isInitialized = true;
        }
    }
}
