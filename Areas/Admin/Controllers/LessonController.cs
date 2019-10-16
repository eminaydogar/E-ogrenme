using Eogrenme.Areas.Admin.ViewModels;
using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eogrenme.Areas.Admin.Controllers
{
    public class LessonController : Controller
    {
        // GET: Admin/Lesson
        public ActionResult Index()
        {
            var _dersler = Database.Session.Query<Dersler>().ToList();
            var _bolumler = Database.Session.Query<Bolumler>().ToList();

            return View(
                
                new LessonArray { dersler=_dersler , bolumler=_bolumler}
                

                );
        }

        public ActionResult Delete(int id)
        {
            var deletelesson = Database.Session.Load<Dersler>(id);
            Database.Session.Delete(deletelesson);
            Database.Session.Flush();
            return RedirectToAction("Index", "Lesson");
        }

        public ActionResult AddLesson(LessonArray form,string Bolumid)
        {
            var addlesson = new Dersler()
            { 
                DersAd = form.DersAdı,
                Ders_Bolum = Database.Session.Load<Bolumler>(Bolumid)
            };
            Database.Session.Save(addlesson);
            Database.Session.Flush();
            return RedirectToAction("Index", "Lesson");

        }
    }
}