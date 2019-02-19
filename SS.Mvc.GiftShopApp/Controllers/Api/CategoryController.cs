using SS.Mvc.GiftShopApp.Core.Models;
using SS.Mvc.GiftShopApp.Core.Models.ContextDB;
using SS.Mvc.GiftShopApp.Service;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SS.Mvc.GiftShopApp.Controllers.Api
{
    [RoutePrefix("api/Category"), EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        private CoreDbContext db = new CoreDbContext();
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [Route ("getAll")]
        [HttpGet]
        public List<Category> GetCategory()
        {
            return _categoryService.GetAll();
        }
        
        [Route ("add")]
        [HttpPost]
        public IHttpActionResult PostCategory (Category Category)
        {
            _categoryService.Save(Category);
            return Ok();
        }

        [Route ("delete/{id}")]
        public IHttpActionResult Delete (int id)
        {
            _categoryService.Delete(id);
            return Ok();
        }
        [Route ("update/{id}")]
        [HttpPut]
        public IHttpActionResult update(int id, Category model)
        {
            _categoryService.Update(model);
            return Ok();

        }
    }
}
