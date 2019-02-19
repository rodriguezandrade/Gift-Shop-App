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

        IEnumerable<Product> GetAll();
    }
}
