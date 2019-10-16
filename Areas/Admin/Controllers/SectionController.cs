using Eogrenme.Areas.Admin.ViewModels;
using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eogrenme.Areas.Admin.Controllers
{
    public class SectionController : Controller
    {
        // GET: Admin/Section
        public ActionResult Index()
        {
            var _bolumler = Database.Session.Query<Bolumler>().ToList();

            return View( 
                new UserArray { bolumler = _bolumler});
        }

        public ActionResult DeleteSection(string BolumID)
        {


            var section = Database.Session.Load<Bolumler>(BolumID);
            Database.Session.Delete(section);
            Database.Session.Flush();
            return RedirectToAction("Index", "Lesson");



        }

        [HttpPost]
        public ActionResult AddSection(SectionIndex form)
        {


            var section = new Bolumler()
            {
                BolumAd = form.Bolumad,
                BolumID = form.Bolumid

            };
            Database.Session.Save(section);
            Database.Session.Flush();
            return RedirectToAction("Index", "Section");



        }




    }
      
    }
