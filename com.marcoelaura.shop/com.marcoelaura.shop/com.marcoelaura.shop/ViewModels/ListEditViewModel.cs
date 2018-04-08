using com.marcoelaura.shop.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace com.marcoelaura.shop.ViewModels
{
    public class ListEditViewModel : BaseViewModel
    {
        public ShopList Item { get; set; }
        public List<ShopListItem> Items { get; set; }

        public ListEditViewModel(ShopList item = null)
        {
            if (item == null)
            {
                item = new ShopList();
                item.ListDate = DateTime.Today;
            }
            else
            {
                //Items = AsyncHelper.RunSync<List<ShopListItem>>(() => 
                //    client.GetTable<ShopListItem>()
                //        .Where(i => i.ShopListId == item.Id)
                //        .ToListAsync());                
                Task<List<ShopListItem>> task = Task.Run<List<ShopListItem>>(async () => await client.GetTable<ShopListItem>()
                    .Where(i => i.ShopListId == item.Id)
                    .WithParameters(new Dictionary<string, string> { { "expand", "ShopItem" } })
                    .ToListAsync());
                Items = task.Result;
            }

            Title = item.Title;
            Item = item;
        }
    }

    internal static class AsyncHelper
    {
        private static readonly TaskFactory _myTaskFactory = new
          TaskFactory(CancellationToken.None,
                      TaskCreationOptions.None,
                      TaskContinuationOptions.None,
                      TaskScheduler.Default);

        public static TResult RunSync<TResult>(Func<Task<TResult>> func)
        {
            return AsyncHelper._myTaskFactory
              .StartNew<Task<TResult>>(func)
              .Unwrap<TResult>()
              .GetAwaiter()
              .GetResult();
        }

        public static void RunSync(Func<Task> func)
        {
            AsyncHelper._myTaskFactory
              .StartNew<Task>(func)
              .Unwrap()
              .GetAwaiter()
              .GetResult();
        }
    }
}