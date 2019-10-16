using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class KayıtTalep
    {
        public virtual int talep_id { get; set; }
        public virtual int Ogrenci_id { get; set; }
        public virtual int Ogretmen_id { get; set; }
        public virtual Dersler Ders_id { get; set; }

    }
    public class KayıtTalepMap : ClassMapping<KayıtTalep>
    {
        public KayıtTalepMap()
        {
            Id(t => t.talep_id, t => t.Generator(Generators.Identity));
            Property(t => t.Ogrenci_id);
            Property(t => t.Ogretmen_id);
            ManyToOne(t => t.Ders_id, t => { t.Column("Ders_id"); t.NotNullable(true); });

        }
    }
}