using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Eogrenme
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                routes.MapRoute("home", "", new { Controller = "login", Action = "login" }));

           routes.MapRoute("ogrenci", "ogrenci", new { Controller = "Ogrenci", Action = "Index" });
            routes.MapRoute("ogretmen", "ogretmen", new { Controller = "Ogretmen", Action = "Index" });
            routes.MapRoute("logout", "logout", new { Controller = "Login", Action = "Logout" });
            routes.MapRoute("lesson", "derslerim", new { Controller = "Ogrenci", Action = "Mylesson" });
            routes.MapRoute("talep", "derstalep", new { Controller = "Ogrenci", Action = "SendRequest" });
            routes.MapRoute("ogretmenim", "ogretmenim", new { Controller = "Ogrenci", Action = "MyTeacher" });
            routes.MapRoute("upload", "up", new { Controller = "Ogretmen", Action = "FileUpload" });
            routes.MapRoute("download", "downloadfile", new { Controller = "Ogretmen", Action = "DownloadFile" });
            routes.MapRoute("downloadfile", "downloadfileogrenci", new { Controller = "Ogrenci", Action = "DownloadFile" });
            routes.MapRoute("ogretmentalep", "ogrtmen_talep", new { Controller = "Ogretmen", Action = "Requests" });
            routes.MapRoute("ogretmentalepsil", "ogrtmen_talepsil", new { Controller = "Ogretmen", Action = "Rejection" });
            routes.MapRoute("ogretmentaleponay", "ogrtmen_taleponay", new { Controller = "Ogretmen", Action = "Confirmation" });
            routes.MapRoute("ogretmendegerlendirme", "ogretmendegerlendirme", new { Controller = "Ogrenci", Action = "Vote" });
            routes.MapRoute("like", "like", new { Controller = "Ogrenci", Action = "Like" });
            routes.MapRoute("dislike", "dislike", new { Controller = "Ogrenci", Action = "Dislike" });


        }
                
           
        }
}


