﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;

namespace Licenta.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var products = new ProductsContainer().GetProducts();//.OrderBy(el => el.Nume);

            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductsContainer.SaveProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                ProductsContainer.SaveProduct(product);
                return RedirectToAction("Index");
            }

            return View(product);
        }


        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var category = new Category();
            category = CategoryContainer.getCategoryById((int)id);

            return View(category);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            CategoryContainer.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}