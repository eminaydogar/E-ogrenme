using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.ViewModel
{
    public class DegerlendirmeArray
    {
        public IEnumerable<Kisiler> ogretmenler { get; set; }
        public IEnumerable<Oylama> oylar { get; set; }

        public IEnumerable<Ogrencioy> ogrencioy { get; set; }
    }
    public class OgrenciMyTeacherArray
    {
        public IEnumerable<Bolum_Ogretmen_Dersler> ogretmenler { get; set; }
        public List<Dersler> farklidersid = new List<Dersler>();
        public IEnumerable<KayıtTalep> talepler { get; set; }

    }
    public class OgrenciMyTeacher
    {

    }
    public class OgrenciMylesson
    {
        public IEnumerable<Bolum_Ogrenci_Dersler> dersler { get; set; }
        public IEnumerable<Pdf> pdfs { get; set; }
    }
    public class Ogrenci
    {
    }
}