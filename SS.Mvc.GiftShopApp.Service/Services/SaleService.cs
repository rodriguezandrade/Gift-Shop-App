using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.dto;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Service
{
    public interface ISaleService
    {
        void Save(Sale model);
        void Checkout(int userId);
    }

    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;
        private readonly ICartRepository _cartRepository;
        public SaleService(ISaleRepository saleRepository, ICartRepository cartRepository)
        {
            _saleRepository = saleRepository;
            _cartRepository = cartRepository;
        }

        public void Save(Sale model)
        {
            throw new NotImplementedException();
        }



        public void Checkout(int userId)
        {
            var cartItems = _cartRepository.GetItemCart(userId);
            var sale = new Sale
            {
                UserId=userId,
                Total = cartItems.Sum(x => x.SubTotal),
                Amount = cartItems.Sum(x => x.Amount),
                Date = DateTime.Now
            };

            sale.Products = new Collection<SaleDetail>();

            foreach (var item in cartItems)
            {
                var saleProduct = new SaleDetail
                {
                    Amount=item.Amount,
                    subTotal=item.SubTotal,
                    SaleId=sale.Id,
                   
                    ProductId = item.ProductId
                };

                sale.Products.Add(saleProduct);
            }

            var result = _saleRepository.Save(sale);

            clearCart(cartItems);
            _cartRepository.SaveChanges();

        }




        private void clearCart(List<CartDto> list)
        {
            foreach (var item in list)
            {
                _cartRepository.Delete(item.Id);
            }
        }
    }

    
}
