using System;
using System.Web;
using System.Web.Mvc;
using Licenta.Models;
using System.Web.Security;
using DatabaseModel;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace Licenta.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (SessionAccessor.LoggedUser != null)
                return RedirectToAction("Home");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult Login(LoginModel logmodel)
        {
            ViewBag.IncorrectUser = true;
            if (ModelState.IsValid)
            {
                SessionAccessor.LoggedUser = UserManager.AuthentificateUser(logmodel.Email, logmodel.Password, logmodel.RememberMe);
                if (SessionAccessor.LoggedUser != null)
                {
                    // Check the remember option for login
                    Session["nume"] = SessionAccessor.LoggedUser.Nume;
                    Session["functie"] = SessionAccessor.LoggedUser.Functie;
                    Session["magazin"] = SessionAccessor.LoggedUser.Magazine;
                    Session["role"] = SessionAccessor.getUserRole();

                    if (logmodel.RememberMe == true)
                    {
                        HttpCookie cookie = new HttpCookie("email");
                        cookie.Value = logmodel.Email.Trim();
                        cookie.Expires = DateTime.Now.AddHours(24);
                        Response.AppendCookie(cookie);
                    }
                    else
                    {
                        Response.Cookies.Remove("email");
                        Response.Cookies["email"].Expires = DateTime.Now;
                    }

                    FormsAuthentication.SetAuthCookie(SessionAccessor.LoggedUser.Nume, logmodel.RememberMe);
                    ViewBag.IncorrectUser = false;
                                      
                    return RedirectToAction("Home");
                }
            }
            return View(logmodel);
        }

        [AllowAnonymous]
        public ActionResult PasswordRecovery()
        {
            var model = new LoginModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public ActionResult PasswordRecovery(LoginModel logmodel)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(logmodel.Email))
                {
                    var body = "<p>{1}{2}</p>";
                    var message = new MailMessage();
                    var password = EmployeeContainer.getPasswordByEmail(logmodel.Email);
                    if (String.IsNullOrWhiteSpace(password))
                    {
                        logmodel.Message = "Email-ul nu exista";
                        return View(logmodel);
                    }
                    message.To.Add(new MailAddress("gsckipper@gmail.com"));
                    message.From = new MailAddress("radutdaniel96@gmail.com");
                    message.Subject = "No-reply password recovery";
                    message.Body = string.Format(body, "Parola dumneavoastra este: ");
                    message.IsBodyHtml = true;

                    using (var smtp = new SmtpClient())
                    {
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new NetworkCredential("radutdaniel96@gmail.com", "metaliza12"); ;
                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 25;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.EnableSsl = true;
                        smtp.Send(message);
                        return RedirectToAction("Login");
                    }
                }
            }catch(Exception ex)
            {
                logmodel.Message = "Nu s-a putut trimite mail-ul";
            }
            
            return View(logmodel);
        }

        public ActionResult Home()
        {
            if (SessionAccessor.LoggedUser == null)
                return RedirectToAction("Login");

            var model = new HomeModel();

            switch (SessionAccessor.getUserRole())
            {
                case 0:  // Funizor
                    var pendingDeliveries = DeliveryContainer.getNrOfPendingDeliveries();
                    model.dashboardMessage1 = "Aveti de făcut " + pendingDeliveries + (pendingDeliveries>1?" livrari":" livrare");
                    var initiatedDeliveries = DeliveryContainer.getNrOfInitiatedDeliveries();
                    var deliveredDeliveries = DeliveryContainer.getNrOfDeliveredDeliveries();
                    var refusedDeliveries = DeliveryContainer.getNrOfRefusedDeliveries();
                    model.chart = "" + initiatedDeliveries +","+ pendingDeliveries + "," + deliveredDeliveries + "," + refusedDeliveries;
                    break;

                case 1:  // Angajat
                    var totalCategories = CategoryContainer.getNrOfCategories();
                    model.dashboardMessage1 = "Gestionaţi " + totalCategories + (totalCategories > 1 ? " categorii" : " categorie");
                    var primaryCategories = CategoryContainer.getNrOfPrimaryCategories();
                    model.chart = "" + primaryCategories + "," + (totalCategories - primaryCategories);

                    var totalProducts = ProductsContainer.getNrOfProducts();
                    model.dashboardMessage2 = "Gestionaţi " + totalProducts + (totalProducts > 1 ? " produse" : " produs");

                    var products3 = ProductsContainer.getNrOfProductsExpiredDays(3);
                    var products7 = ProductsContainer.getNrOfProductsExpiredDays(7);
                    var products30 = ProductsContainer.getNrOfProductsExpiredDays(30);
                    var products0 = ProductsContainer.getNrOfProductsExpired();
                    model.chart2 = "" + products3 + "," + products7 + "," + products30 + "," + products0 ;
                    break;

                case 2:  // Manager
                    var pendingDeliveries2 = DeliveryContainer.getNrOfPendingDeliveries();
                    var initiatedDeliveries2 = DeliveryContainer.getNrOfInitiatedDeliveries();
                    var deliveredDeliveries2 = DeliveryContainer.getNrOfDeliveredDeliveries();
                    var refusedDeliveries2 = DeliveryContainer.getNrOfRefusedDeliveries();
                    model.dashboardMessage1 = "Aveti " + deliveredDeliveries2 + (deliveredDeliveries2 > 1 ? " livrari" : " livrare") + " efectuate";
                    model.chart = "" + initiatedDeliveries2 + "," + pendingDeliveries2 + "," + deliveredDeliveries2 + "," + refusedDeliveries2;

                    var nrEmployees = EmployeeContainer.getNrOfEmployees();
                    var nrManagers = EmployeeContainer.getNrOfEmployees();
                    var nrBosses = EmployeeContainer.getNrOfBosses();
                    var nrSuppliers = EmployeeContainer.getNrOfEmployees();
                    model.dashboardMessage2 = "Sunteţi manager pentru " + nrEmployees + (nrEmployees > 1 ? " angajaţi" : " angajat");
                    model.chart2 = "" + nrEmployees + "," + nrManagers + "," + nrBosses + "," + nrSuppliers;
                    break;

                case 3:  // sef
                    var suppliers = SupplierContainer.getNrOfSuppliers();
                    var cities = SupplierContainer.getTopSuppliersCities(5);
                    model.chart = "";
                    model.cities = "";
                    foreach (var city in cities)
                    {
                        model.cities += city + ',';
                        model.chart  += SupplierContainer.getNrOfSupplierByCity(city).ToString() + ",";  
                    }
                    model.cities = model.cities.Substring(0, model.cities.Length - 1);
                    model.chart  = model.chart.Substring(0, model.chart.Length - 1);

                    model.dashboardMessage1 = "Aveti " + suppliers + (suppliers > 1 ? " furnizori" : " furnizor");

                    var markets = MarketContainer.getNrOfMarkets();
                    var marketsCities = MarketContainer.getTopMarketsCities(5);
                    model.chart2 = "";
                    model.cities2 = "";
                    foreach (var city in marketsCities)
                    {
                        model.cities2 += city + ',';
                        model.chart2 += MarketContainer.getNrOfMarketsByCity(city).ToString() + ",";
                    }
                    model.cities2 = model.cities2.Substring(0, model.cities2.Length - 1);
                    model.chart2 = model.chart2.Substring(0, model.chart2.Length - 1);

                    model.dashboardMessage2 = "Aveti " + markets + (markets > 1 ? " magazine" : " magazin");
                    break;

            }

            return View(model);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Home/Login");
        }
    }
}