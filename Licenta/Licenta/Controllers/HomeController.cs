using System;
using System.Web;
using System.Web.Mvc;
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
      
        public ActionResult Home()
        {
            if (SessionAccessor.LoggedUser == null)
                return RedirectToAction("Login");

            switch (SessionAccessor.getUserRole())
            {
                case 0:
                    ViewBag.
                    break;
            }

            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Home/Login");
        }
    }
}