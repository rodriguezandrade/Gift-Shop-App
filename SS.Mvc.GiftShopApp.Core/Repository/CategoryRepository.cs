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
    public class CategoryRepository : EfRepositoryBase<Category>, ICategoryRepository

    {
        private readonly IWorkspace _workspace;
        public CategoryRepository(IWorkspace workspace) : base(workspace)
        {
            _workspace = workspace;
        }

        void ICategoryRepository.Save(Category model)
        {
            Workspace.Add(model);
            Workspace.SaveChanges();
        }

        void ICategoryRepository.Update(Category model)
        {
            Workspace.Update(model);
            Workspace.SaveChanges();
        }

         void ICategoryRepository.Delete(int id)
        {
            var product = _workspace.Get<Category, int>(id);
            _workspace.Delete(product);
            _workspace.SaveChanges();
        }
    }
}
