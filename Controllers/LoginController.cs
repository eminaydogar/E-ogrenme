using Eogrenme.Models;
using Eogrenme.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Eogrenme.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View(//new Login() {test= "this is my " }

            );
        }
        [HttpPost]
        public ActionResult Login(Login form)
        {
            if (!ModelState.IsValid)
            {
                return View(form);
            }
            
            var user = Database.Session.Query<Kisiler>().FirstOrDefault(k => k.Numara == form.numara && k.Sifre == form.Password);
            FormsAuthentication.SetAuthCookie(form.numara.ToString(), true);

            
            if (user != null)
            {
                if (user.Role.Name == "Ogrenci")
                    return RedirectToAction("Index", "Ogrenci");
                else if (user.Role.Name == "Ogretmen")
                    return RedirectToAction("Index", "Ogretmen");
                else return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });
                        
            }
            else
            {
                ModelState.AddModelError("Hatalı Giriş ", "Tekrar deneyiniz");
                return View(form);
            }



        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Login");
        }

    }
}