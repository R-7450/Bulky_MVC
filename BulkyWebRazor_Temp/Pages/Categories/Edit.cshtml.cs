using BulkyWebRazor_Temp.Data;
using BulkyWebRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyWebRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {

        private readonly ApplicationDbContext _db;

        public Category Category { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int ? id)
        {
            if(id!= null && id!=0)
            {
                Category = _db.Categories.Find(id);
            }
        }
        public IActionResult OnPost()
        {

            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges(); // save all the changes made in this context to database
                TempData["success"] = "Category updated successfully";
                return RedirectToPage("Index"); //it will redirect to action name  index  and execute the code inside that
            }
            return Page();
        }
       
    }
}
