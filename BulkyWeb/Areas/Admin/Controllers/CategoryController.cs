﻿
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;


        }
        public IActionResult Index()
        {
            List<Category> objCategoryList = _unitOfWork.Category.GetAll().ToList(); // command is used all the records from category table
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
                _unitOfWork.Category.Add(obj);
                _unitOfWork.Save(); // save all the changes made in this context to database
                TempData["success"] = "Category created successfully";
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id); // find method work on only primary key only
            //Category? categoryFromDb1 = _Db.Categories.FirstOrDefault(c => c.Id == id);// this is another method to find category list
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost]    // below Edit Action is Post Action
        public IActionResult Edit(Category obj)// when we hit create button after filling form then it create a post request that why we are using httppost
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Update(obj);
                _unitOfWork.Save(); // save all the changes made in this context to database
                TempData["success"] = "Category updated successfully";
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
            Category? categoryFromDb = _unitOfWork.Category.Get(u => u.Id == id); // find method work on only primary key only
            //Category? categoryFromDb1 = _Db.Categories.FirstOrDefault(c => c.Id == id);// this is another method to find category list
            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)// when we hit create button after filling form then it create a post request that why we are using httppost
        {
            Category? obj = _unitOfWork.Category.Get(u => u.Id == id);// since both the method have same name thats why we name this method as deletepost
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Category.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");

        }
    }
}
