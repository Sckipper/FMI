using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;

namespace Licenta.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        // GET: Categoriees
        public ActionResult Index()
        {
            var categories = new CategoryContainer().GetCategories();//.OrderBy(el => el.Nume);

            return View(categories);
        }

        // GET: Categoriees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoriees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryContainer.SaveCategory(category);
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // POST: Categoriees/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoryContainer.SaveCategory(category);
                return RedirectToAction("Index");
            }

            return View(category);
        }


        // GET: Categoriees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = new Category();
            category = CategoryContainer.getCategoryById((int)id);

            return View(category);
        }

        // GET: Categoriees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            CategoryContainer.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}