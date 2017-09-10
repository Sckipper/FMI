using System;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using System.Linq;
using Licenta.Models;

namespace Licenta.Controllers
{
    [Authorize]
    public class DeliveriesController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (SessionAccessor.LoggedUser == null)
            {
                filterContext.Result = RedirectToAction("Login", "Home");
                return;
            }

            if ((int)Session["role"] < 2 && (int)Session["role"] != 0)
            {
                filterContext.Result = RedirectToAction("Home", "Home");
                return;
            }
        }

        // GET: Deliveries
        [Authorize]
        public ActionResult Index()
        {
            var markets = MarketContainer.GetMarkets();
            var suppliers = SupplierContainer.GetSuppliers();
            var delivery = DeliveryContainer.GetDeliveries();

            foreach(var del in delivery)
            {
                del.SupplierName = suppliers.FirstOrDefault(x => x.ID == del.FurnizorID).Nume;
                del.MarketName = markets.FirstOrDefault(x => x.ID == del.MagazinID).Denumire;
            }

            return View(delivery);
        }

        // GET: Deliveries/Create
        [Authorize]
        public ActionResult Create()
        {
            var model = new DeliveryModel();
            model.Markets = MarketContainer.GetMarkets();
            model.Suppliers = SupplierContainer.GetSuppliers();

            return View(model);
        }

        // POST: Deliveries/Create
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                delivery.Status = "Initiata";
                delivery.DataSolicitare = DateTime.Now;
                DeliveryContainer.SaveDelivery(delivery);
                return RedirectToAction("Index");
            }
            var model = new DeliveryModel();
            model.Delivery = delivery;
            return View(model);
        }

        // POST: Deliveries/Edit
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                DeliveryContainer.SaveDelivery(delivery);
                return RedirectToAction("Index");
            }

            return View(delivery);
        }


        // GET: Deliveries/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new DeliveryModel();
            model.Delivery = DeliveryContainer.getDeliveryById((int)id);
            model.Markets = MarketContainer.GetMarkets();
            model.Suppliers = SupplierContainer.GetSuppliers();

            return View(model);
        }

        // GET: Deliveries/Delete/5
        [Authorize]
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            DeliveryContainer.DeleteDelivery(id);

            return RedirectToAction("Index");
        }
    }
}