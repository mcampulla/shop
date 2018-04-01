
namespace com.marcoelaura.shop.Models
{
    public class ShopCategory : BaseObject
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        public int Order { get; set; }
    }
}