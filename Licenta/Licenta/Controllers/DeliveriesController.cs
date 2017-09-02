using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using Licenta.Models;

namespace Licenta.Controllers
{
    [Authorize]
    public class DeliveriesController : Controller
    {
        // GET: Deliveries
        public ActionResult Index()
        {
            var delivery = new DeliveryContainer().GetDeliveries();//.OrderBy(el => el.Nume);

            return View(delivery);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        [HttpPost]
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
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var delivery = new Delivery();
            delivery = DeliveryContainer.getDeliveryById((int)id);

            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            DeliveryContainer.DeleteDelivery(id);

            return RedirectToAction("Index");
        }
    }
}