using SS.Data.EntityFramework;
using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Core.Repository
{
    public class ProductRepository : EfRepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IWorkspace workspace) : base(workspace)
        {
        }

        void IProductRepository.Save(Product model)
        {
            Workspace.Add(model);
            Workspace.SaveChanges();
        }
    }
}
