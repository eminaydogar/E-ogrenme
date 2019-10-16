using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Bolum_Ogretmen_Dersler
    {


        
            public virtual int bolum_ogretmen_dersID { get; set; }
            public virtual Dersler DersID { get; set; }
            public virtual Kisiler Kullanıcı_Numara { get; set; }
            // public virtual Bolumler Kullanıcı_Bolum { get; set; }
            public virtual string Kullanıcı_Bolum { get; set; }
        
        public class Bolum_Ogretmen_DerslerMap : ClassMapping<Bolum_Ogretmen_Dersler>
        {
            public Bolum_Ogretmen_DerslerMap()
            {
                Id(x => x.bolum_ogretmen_dersID, x => x.Generator(Generators.Identity));

                ManyToOne(x => x.DersID, x => {
                    x.Column("DersID");
                    x.NotNullable(true);
                });
                ManyToOne(x => x.Kullanıcı_Numara, x => {
                    x.Column("Kullanıcı_Numara");
                    x.NotNullable(true);
                });

                Property(x => x.Kullanıcı_Bolum);

            }
        }
    }
}