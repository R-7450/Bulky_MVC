
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList(); // command is used all the records from product table
          
            return View(objProductList);
        }
        public IActionResult Create()
        {
               IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
               .GetAll().Select(u => new SelectListItem
               {
                   Text = u.Name,                // using projection in EF core we can do dynamic conversion on type while retreiving data from database
                   Value = u.Id.ToString()
               });

            //  ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)// when we hit create button after filling form then it create a post request that why we are using httppost
        {
            
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.Save(); // save all the changes made in this context to database
                TempData["success"] = "Product created successfully";
                return RedirectToAction("Index"); //it will redirect to action name  index  and execute the code inside that
            }
            return View();

        }
        public IActionResult Edit(int? id)  // if something is not mention by default this will be Get  Action
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id); // find method work on only primary key only
            //Product? productFromDb1 = _Db.Categories.FirstOrDefault(c => c.Id == id);// this is another method to find product list
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]    // below Edit Action is Post Action
        public IActionResult Edit(Product obj)// when we hit create button after filling form then it create a post request that why we are using httppost
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(obj);
                _unitOfWork.Save(); // save all the changes made in this context to database
                TempData["success"] = "Product updated successfully";
                return RedirectToAction("Index"); //it will redirect to action name  index  and execute the code inside that
            }
            return View();

        }
        public IActionResult Delete(int? id)  // if something is not mention by default this will be Get  Action
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id); // find method work on only primary key only
            //Product? productFromDb1 = _Db.Categories.FirstOrDefault(c => c.Id == id);// this is another method to find product list
            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)// when we hit create button after filling form then it create a post request that why we are using httppost
        {
            Product? obj = _unitOfWork.Product.Get(u => u.Id == id);// since both the method have same name thats why we name this method as deletepost
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Product deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
