using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SS.Mvc.GiftShopApp.Service
{

    public class ProductsService : IProductsService
    {
        private readonly IProductRepository _productRepository;
        public ProductsService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public List<ProductDto> GetAll()
        {
            var products = _productRepository
                .GetAllQueryable();

            
            var res = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Cant = p.Cant,
                CategoryId = p.CategoryId,
                Cost = p.Cost,
                Detail = p.Detail,
                Name = p.Name,
                Status = p.Status,

                categoryName = p.Category.Name
            })
            .ToList();

            return res;
        }

        public IQueryable<Product> GetAllQueryable()
        {
            return _productRepository.GetAllQueryable();
        }

        public void Save(Product model)
        {
            _productRepository.Save(model);
        }

        public void Update(Product model)
        {
            _productRepository.Update(model);
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }
    }
}
