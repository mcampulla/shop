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
    public class ShopCategoryController : TableController<ShopCategory>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            MobileServiceContext context = new MobileServiceContext();
            DomainManager = new EntityDomainManager<ShopCategory>(context, Request);
        }

        // GET tables/ShopCategory
        public IQueryable<ShopCategory> GetAllShopCategory()
        {
            return Query(); 
        }

        // GET tables/ShopCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<ShopCategory> GetShopCategory(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/ShopCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<ShopCategory> PatchShopCategory(string id, Delta<ShopCategory> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/ShopCategory
        public async Task<IHttpActionResult> PostShopCategory(ShopCategory item)
        {
            ShopCategory current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/ShopCategory/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteShopCategory(string id)
        {
             return DeleteAsync(id);
        }
    }
}
