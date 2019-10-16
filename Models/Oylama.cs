using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Oylama
    {
        public virtual int id { get; set; }
        public virtual Kisiler Ogretmen_id { get; set; }

        public virtual int Begenme { get; set; }

        public virtual int Begenmeme { get; set; }

    }

    public class OylamaMap : ClassMapping<Oylama>
    {
        public OylamaMap()
        {
            Id(o => o.id, o => o.Generator(Generators.Identity));
            ManyToOne(o => o.Ogretmen_id, o => { o.Column("Ogretmen_id"); o.NotNullable(true); });
            Property(o => o.Begenme);
            Property(o => o.Begenmeme);

        }
    }
}