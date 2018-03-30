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
    public class ShopListItemController : TableController<ShopListItem>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<ShopListItem>(context, Request);
        }

        // GET tables/ShopListItem
        public IQueryable<ShopListItem> GetAllShopListItem()
        {
            return Query(); 
        }

        // GET tables/ShopListItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ShopListItem> GetShopListItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ShopListItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ShopListItem> PatchShopListItem(string id, Delta<ShopListItem> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ShopListItem
        public async Task<IHttpActionResult> PostShopListItem(ShopListItem item)
        {
            ShopListItem current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ShopListItem/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteShopListItem(string id)
        {
             return DeleteAsync(id);
        }
    }
}
