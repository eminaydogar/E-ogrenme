using Eogrenme.Models;
using Eogrenme.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Eogrenme.Controllers
{
    [Authorize(Roles ="Ogrenci")]
    public class OgrenciController : Controller
    {
        // GET: Ogrenci
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Mylesson( )
        {


            var pdfs = Database.Session.Query<Pdf>();
            var mylessons = Database.Session.Query<Bolum_Ogrenci_Dersler>().Where(b => b.Kullanıcı_Numara.Numara == Convert.ToInt32(HttpContext.User.Identity.Name)).ToList(); // kullanıcı numarasından kullanıcının aldıgı dersler
      
         /*  for(int i=0; i<mylessons.Count-1; i++)
            {
                dersid[i] = mylessons[i].DersID.DersId; // alınan derslerin id'si dizide tutuldu. Bu diziyi pdfleri cekerken kullanacagız
                lessonpdfs +=Database.Session.Query<Pdf>().Where(d => d.Ders_id == dersid[i]);
            }
            */
            
            return View(
                
               new OgrenciMylesson { dersler=mylessons,pdfs =pdfs }


                );
        }

        public ActionResult MyTeacher()
        {
            List<Dersler> dersliste = new List<Dersler>();
            int sayac = 0;
            var mylessons = Database.Session.Query<Bolum_Ogrenci_Dersler>().Where(b => b.Kullanıcı_Numara.Numara == Convert.ToInt32(HttpContext.User.Identity.Name)).ToList();
            var myusersection = Database.Session.Load<Kisiler>(Convert.ToInt32(HttpContext.User.Identity.Name));
            var teachers = Database.Session.Query<Bolum_Ogretmen_Dersler>().Where(t => t.Kullanıcı_Bolum == myusersection.Bolum.BolumID).ToList();

            //  Bölümümdeki Öğretmenlerin Verdi Derslerden almadıklarımın id'sini buluyorum. Bunu almadıgım derslere kayıt talep et butonu için kullanacagım
            for (int i = 0; i <= teachers.Count - 1; i++)
            {
                for(int j=0; j <= mylessons.Count - 1; j++)
                {
                    if (teachers[i].DersID.DersId == mylessons[j].DersID.DersId) sayac++;
                }

                if (sayac == 0)
                {
                    dersliste.Add(teachers[i].DersID); //  farklı olan id
                }
                else sayac = 0;
            }

            var talep = Database.Session.Query<KayıtTalep>().ToList();
            return View(
                
                new OgrenciMyTeacherArray { ogretmenler=teachers, farklidersid=dersliste}
                
                
                
                );
        }
        public ActionResult SendRequest(int Numara, int DersID)
        {

            var talep = new KayıtTalep()
            {
                Ogretmen_id = Numara,
                Ogrenci_id = Convert.ToInt32(HttpContext.User.Identity.Name),
                Ders_id = Database.Session.Load<Dersler>(DersID)

            };
            var kontrol = Database.Session.Query<KayıtTalep>().FirstOrDefault(k => k.Ders_id == talep.Ders_id);
            if (kontrol != null)
            {
                return Content("Seçiğiniz ders için kayıt talebiniz sistemde zaten mevcut");
            }
            else
            {
                Database.Session.Save(talep);
                Database.Session.Flush();
                //var kontrol =  Database.Session.Load<KayıtTalep>(talep);
                //     if(kontrol!=null) return Content

                //   return RedirectToAction("MyTeacher", "Ogrenci");
                return Content("Talebiniz başarıyla gönderildi");
            }
           
        }
        public ActionResult DownloadFile(string ad)
        {
            var derskonum = Database.Session.Query<Pdf>().FirstOrDefault(d => d.Dosya_adı == ad && d.Ders_id != null);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=" + ad + ".pdf");
            Response.TransmitFile(derskonum.Dosya_konumu);
            Response.End();
            return Content("indiriliyor..");
        }

        public ActionResult Vote()
        {
         
            var oy = Database.Session.Query<Oylama>();
            var o_oy = Database.Session.Query<Ogrencioy>().Where(o => o.Oylayan_id == Convert.ToInt32(HttpContext.User.Identity.Name)&&o.id!=null);

            return View(

                new DegerlendirmeArray {oylar=oy,ogrencioy=o_oy}

                );
      
        }

        public ActionResult Like(int Ogretmen_id)
        {
            var oykullan = new Ogrencioy()
            {
                Oylayan_id = Convert.ToInt32(HttpContext.User.Identity.Name),
                Oylanan_id = Ogretmen_id
            };
            var oylar = Database.Session.Query<Oylama>().FirstOrDefault(o=>o.Ogretmen_id.Numara==Ogretmen_id);
            oylar.Begenme += 1;
            Database.Session.Save(oykullan);
            Database.Session.Update(oylar);
            Database.Session.Flush();
            return Content("oylama başarılı");
        }
        public ActionResult Dislike(int Ogretmen_id)
        {
            var oykullan = new Ogrencioy()
            {
                Oylayan_id = Convert.ToInt32(HttpContext.User.Identity.Name),
                Oylanan_id = Ogretmen_id
            };

            var oylar = Database.Session.Query<Oylama>().FirstOrDefault(o => o.Ogretmen_id.Numara == Ogretmen_id);
            oylar.Begenmeme += 1;
            Database.Session.Save(oykullan);
            Database.Session.Update(oylar);
            Database.Session.Flush();
            return Content("oylama başarılı");
        }
    }
}