using CodingWiki_DataAccess.Data;
using CodingWiki_Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CodingWiki_Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> objList = _db.Categories.AsNoTracking().ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Category obj = new Category();

            if(id == null || id ==0)
            {
                //create
                return View(obj);
            }

            obj = _db.Categories.FirstOrDefault(u=>u.Category_Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Category obj)
        {
            if(ModelState.IsValid)
            {
                if(obj.Category_Id == 0)
                {
                    //Create
                   await _db.Categories.AddAsync(obj);
                }
                else
                {
                    //Update
                     _db.Categories.Update(obj);
                }

                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);
        }


        public async Task<IActionResult> Delete(int id)
        {

            Category obj = new Category();
            obj = _db.Categories.FirstOrDefault(u => u.Category_Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Categories.Remove(obj);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index)); 
        }

        public IActionResult CreateMultiple2()
        {
            List<Category> categories = new List<Category>(); 
            for(int i = 1; i <= 2; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
               
            }
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult CreateMultiple5()
        {
            List<Category> categories = new List<Category>();
            for (int i = 1; i <= 5; i++)
            {
                categories.Add(new Category { CategoryName = Guid.NewGuid().ToString() });
                
            }
            _db.Categories.AddRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            //IEnumerable<Category> categories = _db.Categories.OrderByDescending(u => u.Category_Id).Take(2);
            List<Category> categories = _db.Categories.OrderByDescending(u => u.Category_Id).Take(2).ToList();
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult RemoveMultiple5()
        {
            List<Category> categories = _db.Categories.OrderByDescending(u => u.Category_Id).Take(5).ToList();
            _db.Categories.RemoveRange(categories);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
