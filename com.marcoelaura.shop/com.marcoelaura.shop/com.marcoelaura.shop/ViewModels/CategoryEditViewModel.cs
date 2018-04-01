using com.marcoelaura.shop.Models;

namespace com.marcoelaura.shop.ViewModels
{
    public class CategoryEditViewModel : BaseViewModel
    {
        public ShopCategory Item { get; set; }

        public CategoryEditViewModel(ShopCategory item = null)
        {
            if (item == null)
                item = new ShopCategory();

            Title = item.Title;
            Item = item;
        }
    }
}