using System.Linq;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using Licenta.Models;
using System.Web;
using System.IO;

namespace Licenta.Controllers
{
    
    public class CategoriesController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string actionName = filterContext.ActionDescriptor.ActionName;
            if (actionName.Equals("GetCategories"))
                return;

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

        [AllowAnonymous]
        public ActionResult GetCategories()
        {
            var categories = CategoryContainer.GetCategories();
            return View(categories);
        }

        // GET: Categories
        [Authorize]
        public ActionResult Index()
        {
            var categories = CategoryContainer.GetCategories();
            foreach(var categ in categories)
                if(categ.CategorieID != null)
                    categ.CategoryName = categories.FirstOrDefault(x => x.ID == categ.CategorieID).Nume;

            return View(categories);
        }

        // GET: Categoriees/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new CategoryModel();
            model.Categories = CategoryContainer.GetCategories();
            return View(model);
        }

        // POST: Categoriees/Create
        [Authorize]
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

                if (CategoryContainer.ValidateCode(category.Cod))
                {
                    CategoryContainer.SaveCategory(category);
                    return RedirectToAction("Index");
                }
            }
            var model = new CategoryModel();
            model.Category = category;
            return View(model);
        }

        // POST: Categoriees/Edit
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase postedFile, CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + categoryModel.Category.Nume.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    categoryModel.Category.Imagine = "img_" + categoryModel.Category.Nume.ToLower();
                }

                if (CategoryContainer.ValidateCode(categoryModel.Category.Cod))
                {
                    CategoryContainer.SaveCategory(categoryModel.Category);
                    return RedirectToAction("Index");
                }
            }
            categoryModel.Categories = CategoryContainer.GetSupperiorCategories();
            return View(categoryModel);
        }


        // GET: Categoriees/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new CategoryModel();
            model.Categories = CategoryContainer.GetSupperiorCategories();
            model.Category = CategoryContainer.getCategoryById((int)id);

            return View(model);
        }

        // GET: Categoriees/Delete/5
        [Authorize]
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