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
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)// when we hit create button after filling form then it create a post request that why we are using httppost
        {
            if (obj.Name == obj.DisplayOrder.ToString()) // this condition is for custom validation 
            {
                ModelState.AddModelError("Name", "DisplayOrder can not match exactly the same");
            }

            if (ModelState.IsValid)
             {
                _Db.Categories.Add(obj);
                _Db.SaveChanges(); // save all the changes made in this context to database
                return RedirectToAction("Index"); //it will redirect to action name  index  and execute the code inside that
             }
          return View();
           
        }
    }
}
