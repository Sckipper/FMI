using System.Linq;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using Licenta.Models;
using System.IO;

namespace Licenta.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Index()
        {
            var products = ProductsContainer.GetProducts();
            var categories = CategoryContainer.GetCategories();
            var markets = MarketContainer.GetMarkets();

            foreach(var prod in products)
            {
                prod.CategoryName = categories.Where(el => el.ID == prod.CategorieID).FirstOrDefault().Nume;
                prod.MarketName = markets.Where(el => el.ID == prod.MagazinID).FirstOrDefault().Denumire;
            }

            return View(products);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            var model = new ProductModel();
            model.Categories = CategoryContainer.GetCategories();
            model.Markets = MarketContainer.GetMarkets();
            return View(model);
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.file != null)
                {
                    var filename = Path.GetFileName(model.file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Uploads/Photo/"), filename);
                    model.file.SaveAs(path);
                }

                ProductsContainer.SaveProduct(model.Product);
                return RedirectToAction("Index");
            }
            return View(model);
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

            var model = new ProductModel();
            model.Product = ProductsContainer.getProductById((int)id);
            model.Categories = CategoryContainer.GetCategories();
            model.Markets = MarketContainer.GetMarkets();

            return View(model);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            ProductsContainer.DeleteProduct(id);

            return RedirectToAction("Index");
        }
    }
}