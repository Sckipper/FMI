﻿using System.Linq;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using Licenta.Models;
using System.Web;
using System.IO;

namespace Licenta.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            var categories = CategoryContainer.GetCategories();
            foreach(var categ in categories)
                if(categ.CategorieID != null)
                    categ.CategoryName = categories.FirstOrDefault(x => x.ID == categ.CategorieID).Nume;

            return View(categories);
        }

        // GET: Categoriees/Create
        public ActionResult Create()
        {
            var model = new CategoryModel();
            model.Categories = CategoryContainer.GetCategories();
            return View(model);
        }

        // POST: Categoriees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase postedFile, Category category)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + category.Nume.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    category.Imagine = "img_" + category.Nume.ToLower();
                }

                CategoryContainer.SaveCategory(category);
                return RedirectToAction("Index");
            }
            var model = new CategoryModel();
            model.Category = category;
            return View(model);
        }

        // POST: Categoriees/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase postedFile, Category category)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + category.Nume.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    category.Imagine = "img_" + category.Nume.ToLower();
                }

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

            var model = new CategoryModel();
            model.Categories = CategoryContainer.GetCategories();
            model.Category = CategoryContainer.getCategoryById((int)id);

            return View(model);
        }

        // GET: Categoriees/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            string serverpath = Server.MapPath("~/Content/ProductsImages/");
            CategoryContainer.DeleteCategory(id, serverpath);

            return RedirectToAction("Index");
        }
    }
}