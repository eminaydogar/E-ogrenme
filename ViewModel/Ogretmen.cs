using Eogrenme.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.ViewModel
{
    public class OgretmenTalepArray
    {
        public IEnumerable<KayıtTalep> talepler { get; set; }
    }
    public class OgretmenArray
    {
        public ArrayList dizi { get; set; }
        
    }
    public class OgretmenIndex
    {
        public string Dosyaadı;
        public string Dosyakonum;
        public int Dersid;
        public int secilenders;
        public IEnumerable<Pdf> dosyalar { get; set; }
        public IEnumerable<Bolum_Ogretmen_Dersler> verilendersler { get; set; }
    }
}