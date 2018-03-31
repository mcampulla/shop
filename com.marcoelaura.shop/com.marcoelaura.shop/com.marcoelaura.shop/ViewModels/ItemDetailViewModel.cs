using com.marcoelaura.shop.Models;

namespace com.marcoelaura.shop.ViewModels
{
  public class ItemDetailViewModel : BaseViewModel
  {
    public ShopList Item { get; set; }
    public ItemDetailViewModel(ShopList item = null)
    {
      Title = item.Title;
      Item = item;
    }

    int quantity = 1;
    public int Quantity
    {
      get { return quantity; }
      set { SetProperty(ref quantity, value); }
    }
  }
}