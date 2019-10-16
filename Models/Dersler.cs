using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Dersler
    {
        public virtual int DersId { get; set; }
        public virtual string DersAd { get; set; }

        public virtual Bolumler Ders_Bolum { get; set; }
        public class DerslerMap : ClassMapping<Dersler>
        {
            public DerslerMap()
            {
                Table("Dersler");
                Id(x => x.DersId, x => x.Generator(Generators.Identity));
                Property(x => x.DersAd, x => x.NotNullable(true));

                ManyToOne(x => x.Ders_Bolum, x =>
                {    x.Column("Ders_Bolum");
                    x.NotNullable(true);
                });


            }
        }
    }
}


