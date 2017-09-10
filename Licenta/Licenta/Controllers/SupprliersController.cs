using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using Licenta.Models;

namespace Licenta.Controllers
{
    [Authorize]
    public class SuppliersController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionAccessor.LoggedUser == null)
            {
                filterContext.Result = RedirectToAction("Login", "Home");
                return;
            }

            if ((int)Session["role"] < 3)
            {
                filterContext.Result = RedirectToAction("Home", "Home");
                return;
            }
        }

        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = SupplierContainer.GetSuppliers();

            return View(suppliers);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                SupplierContainer.SaveSupplier(supplier);
                return RedirectToAction("Index");
            }
            var model = new SupplierModel();
            model.Supplier = supplier;

            return View(model);
        }

        // POST: Deliveries/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                SupplierContainer.SaveSupplier(supplier);
                return RedirectToAction("Index");
            }

            return View(supplier);
        }


        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new SupplierModel();
            model.Supplier = SupplierContainer.getSupplierById((int) id);

            return View(model);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            SupplierContainer.DeleteSupplier(id);

            return RedirectToAction("Index");
        }
    }
}