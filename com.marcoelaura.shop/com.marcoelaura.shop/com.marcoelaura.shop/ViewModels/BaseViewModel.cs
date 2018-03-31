using com.marcoelaura.shop.Helpers;
using com.marcoelaura.shop.Models;
using com.marcoelaura.shop.Services;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace com.marcoelaura.shop.ViewModels
{
  public class BaseViewModel : ObservableObject
  {
    /// <summary>
    /// Get the azure service instance
    /// </summary>
    public IDataStore<ShopList> DataStore => DependencyService.Get<IDataStore<ShopList>>();
    public MobileServiceClient client = new MobileServiceClient("https://api-shop.azurewebsites.net");

        bool isBusy = false;
    public bool IsBusy
    {
      get { return isBusy; }
      set { SetProperty(ref isBusy, value); }
    }
    /// <summary>
    /// Private backing field to hold the title
    /// </summary>
    string title = string.Empty;
    /// <summary>
    /// Public property to set and get the title of the item
    /// </summary>
    public string Title
    {
      get { return title; }
      set { SetProperty(ref title, value); }
    }
  }
}

