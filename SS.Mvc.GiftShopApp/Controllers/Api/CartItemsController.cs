using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.ContextDB;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using Microsoft.AspNet.Identity;

namespace SS.Mvc.GiftShopApp.Controllers.Api
{
    [RoutePrefix("api/cartitem")]
    public class CartItemsController : ApiController
    {
        private readonly ICartRepository _cartRepository;
      

        public CartItemsController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;

        }   
        private CoreDbContext db = new CoreDbContext();


        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetItemCart()
        {
                var userId = User.Identity.GetUserId<int>();

                var data = _cartRepository.GetItemCart(userId);

                return Ok(data);
             
        }

        // PUT: api/CartItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartItem(int id, CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartItem.Id)
            {
                return BadRequest();
            }

            db.Entry(cartItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
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

        // POST: api/CartItems
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult PostCartItem(CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Cart.Add(cartItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartItem.Id }, cartItem);
        }

        // DELETE: api/CartItems/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult DeleteCartItem(int id)
        {
            var userId = User.Identity.GetUserId<int>();
            CartItem cartItem = db.Cart.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            db.Cart.Remove(cartItem);
            db.SaveChanges();

            return Ok(cartItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartItemExists(int id)
        {
            return db.Cart.Count(e => e.Id == id) > 0;
        }

        
    }
}