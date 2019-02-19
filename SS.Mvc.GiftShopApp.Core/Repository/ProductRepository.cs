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
        private readonly IWorkspace _workspace;
        public ProductRepository(IWorkspace workspace) : base(workspace)
        {
            _workspace = workspace;
        }

        void IProductRepository.Save(Product model)
        {
            Workspace.Add(model);
            Workspace.SaveChanges();
        }

        void IProductRepository.Update(Product model)
        {
            this.Workspace.Query<User>().Where( user => user.Roles.Where( roles => roles.Id == 40).Count() > 0 ).ToList();
            Workspace.Update(model);
            Workspace.SaveChanges();
        }

        void IProductRepository.Delete(int id)
        {
            var product = _workspace.Get<Product, int>(id);
            _workspace.Delete(product);
            _workspace.SaveChanges();
        }

        public IQueryable<Product> GetAllQueryable()
        {
            return _workspace.Query<Product>();
        }
    }
}
