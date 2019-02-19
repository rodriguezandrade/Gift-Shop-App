using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SS.Mvc.GiftShopApp.Service
{
    
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> GetAll()
        {
           return _categoryRepository.GetAll().ToList();
        }

        public void Save(Category model)
        {
            _categoryRepository.Save(model);
        }
        
        public void Update(Category model)
        {
            _categoryRepository.Update(model);
        }

        public void Delete(int id)
        {    
            _categoryRepository.Delete(id);
        }
    }
}
