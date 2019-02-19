using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.ContextDB;
using Microsoft.AspNet.Identity;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using SS.Mvc.GiftShopApp.Service;

namespace SS.Mvc.GiftShopApp.Controllers.Api
{
    [RoutePrefix("api/sales")]
    public class SalesController : ApiController
    {
        private CoreDbContext db = new CoreDbContext();
        private readonly ISaleService _saleService;
        private readonly ISaleRepository _saleRepository;

        public SalesController(ISaleService saleService, ISaleRepository saleRepository )
        {
            _saleService = saleService;
            _saleRepository = saleRepository;
        }
        [Route("Getsales")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetSales()
        {
            var userId = User.Identity.GetUserId<int>();

            var data = _saleRepository.GetDto(userId);

            return Ok(data);

        }
        // GET: api/Sales
        public IQueryable<Sale> GetSale()
        {
            return db.Sale;
        }

        // GET: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult GetSale(int id)
        {
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            return Ok(sale);
        }

        // PUT: api/Sales/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSale(int id, Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sale.Id)
            {
                return BadRequest();
            }

            db.Entry(sale).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sales
        [ResponseType(typeof(Sale))]
        public IHttpActionResult PostSale(Sale sale)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sale.Add(sale);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sale.Id }, sale);
        }

        // DELETE: api/Sales/5
        [ResponseType(typeof(Sale))]
        public IHttpActionResult DeleteSale(int id)
        {
            Sale sale = db.Sale.Find(id);
            if (sale == null)
            {
                return NotFound();
            }

            db.Sale.Remove(sale);
            db.SaveChanges();

            return Ok(sale);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SaleExists(int id)
        {
            return db.Sale.Count(e => e.Id == id) > 0;
        }

        [Route("chekout")]
        [HttpPost]
        public IHttpActionResult Checkout()
        {

           var userId = User.Identity.GetUserId<int>();

           _saleService.Checkout(userId);

            return Ok();

        }

    }
}