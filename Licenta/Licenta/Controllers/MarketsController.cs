using System;
using System.Web.Mvc;
using DatabaseModel;
using System.Net;
using System.Linq;
using Licenta.Models;
using System.Web;
using System.IO;

namespace Licenta.Controllers
{
    [Authorize]
    public class MarketsController : Controller
    {
        // GET: Suppliers
        public ActionResult Index()
        {
            var markets = MarketContainer.GetMarkets();

            return View(markets);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Deliveries/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase postedFile, Market market)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + market.Denumire.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    market.Imagine = "img_" + market.Denumire.ToLower();
                }

                MarketContainer.SaveMarket(market);
                return RedirectToAction("Index");
            }
            var model = new MarketModel();
            model.Market = market;

            return View(model);
        }

        // POST: Deliveries/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase postedFile, Market market)
        {
            if (ModelState.IsValid)
            {
                if (postedFile != null)
                {
                    var filename = "img_" + market.Denumire.ToLower() + ".png";
                    var path = Path.Combine(Server.MapPath("~/Content/ProductsImages/"), filename);
                    postedFile.SaveAs(path);
                    market.Imagine = "img_" + market.Denumire.ToLower();
                }

                MarketContainer.SaveMarket(market);
                return RedirectToAction("Index");
            }

            return View(market);
        }


        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var model = new MarketModel();
            model.Market = MarketContainer.getMarketById((int) id);

            return View(model);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int id)
        {
            if (id < 1)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            string serverpath = Server.MapPath("~/Content/ProductsImages/");
            MarketContainer.DeleteMatket(id, serverpath);

            return RedirectToAction("Index");
        }
    }
}