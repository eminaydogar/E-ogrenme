using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Ogrencioy
    {
        public virtual int id { get; set; }
        public virtual int Oylayan_id { get; set; }
        public virtual int Oylanan_id { get; set; }
    }

    public class OgrencioyMap : ClassMapping<Ogrencioy>
    {
        public OgrencioyMap()
        {

            Id(o => o.id, o => o.Generator(Generators.Identity));
            Property(o => o.Oylayan_id);
            Property(o => o.Oylanan_id);
           
        }
    }
}