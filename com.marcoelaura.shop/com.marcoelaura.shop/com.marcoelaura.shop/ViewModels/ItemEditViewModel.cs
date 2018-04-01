using com.marcoelaura.shop.Helpers;
using com.marcoelaura.shop.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace com.marcoelaura.shop.ViewModels
{
    public class ItemEditViewModel : BaseViewModel
    {
        public Command LoadItemsCommand { get; set; }
        public ShopItem Item { get; set; }

        public ShopCategory Category { get; set; }

        private int categoryIndex;
        public int CategoryIndex
        {
            get { return categoryIndex; }
            set { SetProperty(ref categoryIndex, value); }
        }

        public ObservableRangeCollection<ShopCategory> Categories { get; set; }
        private IMobileServiceTable<ShopItem> table;

        public ItemEditViewModel(ShopItem item = null)
        {
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
            Categories = new ObservableRangeCollection<ShopCategory>();

            if (item == null)
            {
                item = new ShopItem();
            }
            Title = item.Title;
            Item = item;
           
        }

        public async Task Save()
        {
            Item.CategoryId = Category.Id;
            table = client.GetTable<ShopItem>();
            try
            {
                if (Item.Id == null)
                    await table.InsertAsync(Item);
                else
                    await table.UpdateAsync(Item);
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var items = await client.GetTable<ShopCategory>().ToListAsync();
                Categories.Clear();
                Categories.ReplaceRange(items);
                Category = await client.GetTable<ShopCategory>().LookupAsync(Item.CategoryId);
                for(int x = 0; x < Categories.Count; x++)
                {
                    if (Categories[x].Id == Item.CategoryId)
                        CategoryIndex = x;
                }
            }
            catch (Exception ex)
            {
              
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}