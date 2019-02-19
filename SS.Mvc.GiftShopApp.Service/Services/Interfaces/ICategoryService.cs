using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Service
{
    public interface ICategoryService
    {
        void Save(Category model);
        void Delete(int id);
        List<Category> GetAll();
        void Update(Category model);
    }
}
