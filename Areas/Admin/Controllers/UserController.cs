
using Eogrenme.Areas.Admin.ViewModels;
using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eogrenme.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index(int id=0)
        {
            var users = Database.Session.Query<Kisiler>().ToList();
            return View( new UserArray { Kisilers=users}
                );
        }

        public ActionResult AddUser()
        {
            var bölümler = Database.Session.Query<Bolumler>().ToList();

            var _roller = Database.Session.Query<Role>().ToList();
            return View(
                
                new UserArray { bolumler=bölümler,roller=_roller }
                
                );
        }

     [HttpPost]
        public ActionResult AddUser(UserArray form ,string bolum,string roll)
        {

            if (Database.Session.Load<Kisiler>(form.numara) != null)
            {
                return Content(form.numara+" id'sine sahip bir kullanıcı mevcut");
            }
            else
            {
                var adduser = new Kisiler()
                {
                    Numara = form.numara,
                    Ad = form.ad,
                    Soyad = form.soyad,
                    Sifre = form.sifre,
                    Role = Database.Session.Query<Role>().FirstOrDefault(r => r.Name == roll),
                    Bolum = Database.Session.Query<Bolumler>().FirstOrDefault(r => r.BolumID == bolum)
                    //     Bolum = Database.Session.Query<Bolumler>().FirstOrDefault(r => r.BolumID == "PC101")

                };
                Database.Session.Save(adduser);
                Database.Session.Flush();
                return RedirectToAction("Index", "HomeAdmin");

            }
          
        }

        public ActionResult DeleteUser(int id)
        {
            var deleteuser = Database.Session.Load<Kisiler>(id);
            Database.Session.Delete(deleteuser);
            Database.Session.Flush();
            return RedirectToAction("Index","User");

        }
    }
}