using Eogrenme.Models;
using Eogrenme.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Eogrenme.Controllers
{

    [Authorize(Roles = "Ogretmen")]
    public class OgretmenController : Controller
    {
        // GET: Ogretmen
        public ActionResult Index( )
        {
            var dosya = Database.Session.Query<Pdf>().Where(d => d.Ogretmen_id.Numara == Convert.ToInt32(HttpContext.User.Identity.Name) && d.id!=null);
            var _verilendersler = Database.Session.Query<Bolum_Ogretmen_Dersler>().Where(v => v.Kullanıcı_Numara.Numara == Convert.ToInt32(HttpContext.User.Identity.Name) && v.bolum_ogretmen_dersID != null);
           if (dosya != null)
            {

                return View(

                    new OgretmenIndex { dosyalar = dosya, verilendersler=_verilendersler}

                    );
            };

            return View();
        }

      
        public ActionResult FileUpload(HttpPostedFileBase pdf,string dosyaadı,string secilenders)
        {
          //  var Dersidbul = Database.Session.Query<Bolum_Ogretmen_Dersler>().FirstOrDefault(d => d.Kullanıcı_Numara.Numara == Convert.ToInt32(HttpContext.User.Identity.Name));
           // var dersidal = Database.Session.Query<Dersler>().FirstOrDefault(d => d.DersId == Dersidbul.DersID.DersId);
            
             bool iscontenttype(string ctype)
            {
                return ctype.Equals("application/pdf");
            }

                if (!iscontenttype(pdf.ContentType))
                {
                return Content("UYUMSUZ DOSYA TİPİ. LÜTFEN PDF TİPİNDE BİR DOSYA GİRİNİZ");
                }
            else
            {

                var filename = Path.GetFileName(pdf.FileName);
                    var path = Path.Combine(Server.MapPath("~/PDFfile"), filename);
                    pdf.SaveAs(path);


                var pdffiles = new Pdf()
                {
                    Dosya_adı = dosyaadı,
                    Dosya_konumu = path,
                    Ders_id = Database.Session.Query<Dersler>().FirstOrDefault(d=>d.DersAd==secilenders),
                    Ogretmen_id = Database.Session.Load<Kisiler>(Convert.ToInt32(HttpContext.User.Identity.Name))
               

                };
                Database.Session.Save(pdffiles);
                Database.Session.Flush();

                return RedirectToAction("Index", "Ogretmen");
            }

            
            }

      
           public ActionResult DownloadFile(string ad)
        {
            var derskonum = Database.Session.Query<Pdf>().FirstOrDefault(d => d.Dosya_adı == ad && d.Ders_id != null);
            Response.Clear();
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename="+ad+".pdf");
            Response.TransmitFile(derskonum.Dosya_konumu);
            Response.End();
            return Content("indiriliyor..");
        }
           
        [HttpGet]
        public ActionResult Requests()
        {
            var _talepler = Database.Session.Query<KayıtTalep>().Where(t => t.Ogretmen_id == Convert.ToInt32(HttpContext.User.Identity.Name) && t.talep_id != null);

            return View(
                new OgretmenTalepArray { talepler=_talepler}

                );
        }
        public ActionResult Rejection(int Ogrenci_id,int DersId)
        {
            var redtalep = Database.Session.Query<KayıtTalep>().FirstOrDefault(r => r.Ogrenci_id == Ogrenci_id && r.Ders_id.DersId == DersId && r.talep_id != null);
            Database.Session.Delete(redtalep);
            Database.Session.Flush();
            return RedirectToAction("Requests", "Ogretmen");

        }

        public ActionResult Confirmation(int Ogrenci_id,int DersId)
        {
            var onaytalep = Database.Session.Query<KayıtTalep>().FirstOrDefault(r => r.Ogrenci_id == Ogrenci_id && r.Ders_id.DersId == DersId && r.talep_id != null);
            var me = Database.Session.Load<Kisiler>(Convert.ToInt32(HttpContext.User.Identity.Name));
            var yenidersogrenci = new Bolum_Ogrenci_Dersler()
            {
                DersID = Database.Session.Load<Dersler>(DersId),
                Kullanıcı_Numara = Database.Session.Load<Kisiler>(Ogrenci_id),
                Kullanıcı_Bolum = me.Bolum.BolumID
            };
            Database.Session.Save(yenidersogrenci);
           Database.Session.Delete(onaytalep);
            Database.Session.Flush();

            return Content("Ders onaylama işlemi başarılı");


        }



        }



    }


        

    
