using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Services
{
    public interface IProductsService
    {
        void Save(Product model);

        List<Product> GetAll();
    }

    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<Product> GetAll()
        {
           return _productRepository.GetAll().ToList();
        }

        public void Save(Product model)
        {
            _productRepository.Save(model);
        }
    }
}
