using Eogrenme.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Areas.Admin.ViewModels
{
    public class LessonArray
    {
        public IEnumerable<Dersler> dersler { get; set; }
        public IEnumerable<Bolumler> bolumler { get; set; }
        public string DersAdı { get; set; }

        public string Bolumid { get; set; }
    }
    public class LessonIndex
    {
    }
}