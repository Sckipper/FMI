using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Oracle.DataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Licenta.Models;
using System.Web.Security;
using DatabaseModel;

namespace Licenta.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
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
                    FormsAuthentication.SetAuthCookie(SessionAccessor.LoggedUser.Nume, true);
                    ViewBag.IncorrectUser = false;
                    return RedirectToAction("Home");
                }
            }
            return View(logmodel);
        }

        public ActionResult Home()
        {

            return View();
        }
    }
}