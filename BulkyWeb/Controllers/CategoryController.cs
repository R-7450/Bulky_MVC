using BulkyWeb.Data;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _Db;
        public CategoryController(ApplicationDbContext db)
        {
            _Db = db;
            
        }
        public IActionResult Index()
        {
           List<Category>  objCategoryList = _Db.Categories.ToList(); // command is used all the records from category table
            return View(objCategoryList);
        }
    }
}
