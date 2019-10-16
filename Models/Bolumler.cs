using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Bolumler
    {
        public virtual string BolumID { get; set; }
        public virtual string BolumAd { get; set; }
    }
    public class BolumlerMap : ClassMapping<Bolumler>
    {
        public BolumlerMap()
        {
            Id(x => x.BolumID);
            Property(x => x.BolumAd);
        }
    }
}