using System.Linq;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using Licenta.Models;
using System.IO;
using System.Web;

namespace Licenta.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionAccessor.LoggedUser == null)
            {
                filterContext.Result = RedirectToAction("Login", "Home");
                return;
            }

            if ((int)Session["role"] < 1)
            {
                filterContext.Result = RedirectToAction("Home", "Home");
                return;
            }
        }

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
        public ActionResult Create(HttpPostedFileBase postedFile, ProductModel model)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + model.Product.Denumire.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    model.Product.Imagine = "img_" + model.Product.Denumire.ToLower();
                }

                ProductsContainer.SaveProduct(model.Product);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        // POST: Products/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase postedFile, Product product)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + product.Denumire.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    product.Imagine = "img_" + product.Denumire.ToLower();
                }

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

            string serverpath = Server.MapPath("~/Content/ProductsImages/");
            ProductsContainer.DeleteProduct(id, serverpath);

            return RedirectToAction("Index");
        }
    }
}