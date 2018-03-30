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
    public class ShopListController : TableController<ShopList>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<ShopList>(context, Request);
        }

        // GET tables/ShopList
        public IQueryable<ShopList> GetAllShopList()
        {
            return Query(); 
        }

        // GET tables/ShopList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ShopList> GetShopList(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ShopList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ShopList> PatchShopList(string id, Delta<ShopList> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ShopList
        public async Task<IHttpActionResult> PostShopList(ShopList item)
        {
            ShopList current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ShopList/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteShopList(string id)
        {
             return DeleteAsync(id);
        }
    }
}
