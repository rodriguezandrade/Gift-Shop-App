using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.dto;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Service
{
    public interface IProductsService
    {
        void Save(Product model);
        void Delete(int id);
        List<ProductDto> GetAll();
        IQueryable<Product> GetAllQueryable();
        void Update(Product model);
    }
}
