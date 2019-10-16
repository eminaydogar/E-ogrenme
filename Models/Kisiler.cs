using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Kisiler
    {
        public virtual int Numara { get; set; }
        public virtual string Ad { get; set; }
        public virtual string Soyad { get; set; }
        public virtual string Sifre { get; set; }

        public virtual Bolumler Bolum { get; set; }

        public virtual  Role Role { get; set; }

        public virtual string Email { get; set; }

    }
    



    public class KisilerMap: ClassMapping<Kisiler>
    {
        public KisilerMap()
        {
            Table("Kisiler");
            Id(x => x.Numara);
            Property(x => x.Ad, x => x.NotNullable(true));
            Property(x => x.Soyad, x => x.NotNullable(true));
            Property(x => x.Sifre, x => x.NotNullable(true));

            ManyToOne(x => x.Role, x => {
                x.Column("Role");
                x.NotNullable(true);
            });

            ManyToOne(x => x.Bolum, x => {
                x.Column("Bolum");
                x.NotNullable(true);
            });
            Property(k => k.Email);

        }
    }
}