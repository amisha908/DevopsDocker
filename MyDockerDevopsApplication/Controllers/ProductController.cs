using Microsoft.AspNetCore.Mvc;
using MyDockerDevopsApplication.DataModel;
using MyDockerDevopsApplication.DBContext;
using MyDockerDevopsApplication.Models;

namespace MyDockerDevopsApplication.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly AppDBContext _db;

        public ProductController(AppDBContext db)
        {
            _db = db;
        }
        [HttpGet]
        [Route("GetProduct")]
        public async Task<IActionResult> GetProductList()
        {
            return Ok(_db.Products.ToList());
        }
        [HttpPost]
        [Route("PostProduct")]
        public async Task<IActionResult> PostProductList(ProductModel obj)
        {
            ProductDataModel model = new ProductDataModel();
            model.Id=Guid.NewGuid();
            model.Name=obj.Name;
            model.Category=obj.Category;
            model.Price=obj.Price;

            _db.Products.Add(model);
            _db.SaveChanges();
            return Ok(model);
     
        }

    }
}
