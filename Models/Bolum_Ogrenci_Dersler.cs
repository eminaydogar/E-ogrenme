using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Cfg;

namespace Eogrenme.Models
{
    public class Bolum_Ogrenci_Dersler
    {
        public virtual int bolum_ogrenci_dersID { get; set; }
        public virtual Dersler DersID { get; set; }
        public virtual Kisiler Kullanıcı_Numara { get; set; }
        // public virtual Bolumler Kullanıcı_Bolum { get; set; }
        public virtual string Kullanıcı_Bolum { get; set; }
    }
    public class Bolum_Ogrenci_DerslerMap: ClassMapping<Bolum_Ogrenci_Dersler>
    {
        public Bolum_Ogrenci_DerslerMap()
        {
            Id(x => x.bolum_ogrenci_dersID, x => x.Generator(Generators.Identity));
            Property(x => x.Kullanıcı_Bolum);
            
                ManyToOne(x => x.DersID, x => {
                  x.Column("DersID");
                  x.NotNullable(true);
              });
         

            ManyToOne(x => x.Kullanıcı_Numara, x => {
                x.Column("Kullanıcı_Numara");
                x.NotNullable(true);
            });


        }
    }
}