using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using com.marcoelaura.shop.api.DataObjects;
using com.marcoelaura.shop.api.Models;

namespace com.marcoelaura.shop.api.Controllers
{
    public class ShopItemController : TableController<ShopItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<ShopItem>(context, Request);
        }

        // GET tables/ShopItem
        public IQueryable<ShopItem> GetAllShopItem()
        {
            return Query(); 
        }

        // GET tables/ShopItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ShopItem> GetShopItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ShopItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ShopItem> PatchShopItem(string id, Delta<ShopItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ShopItem
        public async Task<IHttpActionResult> PostShopItem(ShopItem item)
        {
            ShopItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ShopItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteShopItem(string id)
        {
             return DeleteAsync(id);
        }
    }
}
