using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Areas.Admin.ViewModels
{
    public class UserArray
    {
        public IEnumerable<Bolumler> bolumler { get; set; }
        public IEnumerable<Kisiler> Kisilers { get; set; }
        public IEnumerable<Role> roller { get; set; }
        public int numara { get; set; }
        public string ad { get; set; }
        public string soyad { get; set; }
        public string sifre { get; set; }
        public string roll { get; set; }
        public string bolum { get; set; }
    }


    public class User
    {

        


    }
}