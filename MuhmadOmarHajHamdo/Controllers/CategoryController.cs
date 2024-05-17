using Microsoft.AspNetCore.Mvc;
using MuhmadOmarHajHamdo.Models;

namespace MuhmadOmarHajHamdo.Controllers
{
    public class CategoryController : Controller
    {
        // GET: CategoryController
        public ActionResult Index()
        {
            return View(Category.Categories);
        }

        // GET: CategoryController/Details/5
        public ActionResult Details(int id)
        {
            Category? category = Category.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        // GET: CategoryController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // Extract the category name from the form
                string? categoryName = collection["Name"];
                int categoryId = Convert.ToInt32(collection["Id"]);

                // Create a new category instance
                var newCategory = new Category(id: categoryId, name: categoryName ?? "");

                // Add the new category to the list
                Category.Categories.Add(newCategory);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Edit/5
        public ActionResult Edit(int id)
        {
            Category? category = Category.Categories.FirstOrDefault(c => c.Id == id);

            return View(category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Find the category by ID
                var category = Category.Categories.FirstOrDefault(c => c.Id == id);
                if (category != null)
                {
                    // Update the category's properties
                    category.Name = collection["Name"];
                    // Optionally, handle other properties

                    // Save changes back to the list/database/etc.
                    // For a real application, this would involve updating the data store

                    return RedirectToAction(nameof(Index));
                }

                return NotFound();
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public ActionResult Delete(int id)
        {
            Category? category = Category.Categories.FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                Category? category = Category.Categories.FirstOrDefault(c => c.Id == id);
                if (category != null)
                {
                    Category.Categories.Remove(category);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}