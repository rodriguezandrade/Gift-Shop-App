using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.ContextDB;
using System.Web.Http.Cors;
using SS.Mvc.GiftShopApp.Service;

namespace SS.Mvc.GiftShopApp.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/Products"), EnableCors(origins: "*", headers: "*", methods: "*")]
    //[Authorize(Roles = "admin")]
    public class ProductsController : ApiController
    {
        private CoreDbContext db = new CoreDbContext();
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productsService)
        {
            _productService = productsService;
        }

       
        [Route("getAll")]
        // GET: api/Products
        public IHttpActionResult GetProduct()
        {
            var res = _productService.GetAll();
            return Ok(res);
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Product.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [Route("update/{id}")]
        [HttpPut]
        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Update(int id, Product model)
        {
            _productService.Update(model);
            return Ok();


        }
        [Route("add")]
        [HttpPost]
        // POST: api/Products
        // [Authorize (Roles = "Admin")]
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            _productService.Save(product);
            return Ok();
        }

        [Route("delete/{id}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _productService.Delete(id);
            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Product.Count(e => e.Id == id) > 0;
        }
    }
}