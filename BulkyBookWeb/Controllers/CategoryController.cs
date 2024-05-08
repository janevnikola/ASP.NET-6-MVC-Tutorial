using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
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
            IEnumerable<Category> ListCategories = _db.Categories;
            return View(ListCategories);
        }

        //GET method
        public IActionResult Create()
        {
            return View();
        }
        //POST method
        [HttpPost] //morame da napiseme HttpPost za da naglasime deka ovaa funkcija e post method
        [ValidateAntiForgeryToken] //morame da validime deka ne se koristi CSRF
        public IActionResult Create(Category newCategory)
        {

            if (newCategory.Name == newCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name","The display order cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(newCategory);
                _db.SaveChanges();
                TempData["success"] = "Category successfully created"; //ke kreirame tempData pred da napravime redirect
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }

        //GET
        public IActionResult Edit(int ? id)
        {
            if(id == null || id==0) //ako id e null ili 0
            {
                return NotFound();
            }
            //ako ne e:
            var categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)//ako ne e najdeno nisto so takov id
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        //POST method
        [HttpPost] //morame da napiseme HttpPost za da naglasime deka ovaa funkcija e post method
        [ValidateAntiForgeryToken] //morame da validime deka ne se koristi CSRF
        public IActionResult Edit(Category newCategory)
        {

            if (newCategory.Name == newCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The display order cannot exactly match the name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Update(newCategory);
                _db.SaveChanges();
                TempData["success"] = "Category successfully updated"; //ke kreirame tempData pred da napravime redirect
                return RedirectToAction("Index");
            }
            return View(newCategory);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0) //ako id e null ili 0
            {
                return NotFound();
            }
            //ako ne e:
            var categoryFromDB = _db.Categories.Find(id);
            if (categoryFromDB == null)//ako ne e najdeno nisto so takov id
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }




        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCategory(int?id)
        {

            var categoryFromDB = _db.Categories.Find(id);//go naogjame Category spored id
            if(categoryFromDB == null)//dokolku e null
            {
                return NotFound();//vrati ne postoi
            }

             _db.Categories.Remove(categoryFromDB);//izbrisi go od databazata
             _db.SaveChanges();//zacuvaj gi promenite
            TempData["success"] = "Category successfully deleted"; //ke kreirame tempData pred da napravime redirect
            return RedirectToAction("Index");//redirect do Index page od Categories    
           
        }


    }
}
