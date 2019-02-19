using SS.Mvc.GiftShopApp.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Repository.Interfaces
{
    public interface IProductRepository
    {

        void Save(Product model);
        void Update(Product model);
        void Delete(int id);

        IEnumerable<Product> GetAll();
        IQueryable<Product> GetAllQueryable();
    }
}
