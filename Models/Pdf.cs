using NHibernate.Mapping.ByCode;
using NHibernate.Mapping.ByCode.Conformist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eogrenme.Models
{
    public class Pdf
    {
        public virtual int id { get; set; }
        public virtual string Dosya_adı{ get; set; }
        public virtual string Dosya_konumu { get; set; }
        public virtual Dersler Ders_id { get; set; }
        public virtual Kisiler Ogretmen_id { get; set; }


    }

    public class PdfMap : ClassMapping<Pdf>
    {
        public PdfMap()
        {
            Id(p => p.id, p => p.Generator(Generators.Identity));
            Property(p => p.Dosya_adı);
            Property(p => p.Dosya_konumu);
            //    Property(p => p.Ders_id);

            ManyToOne(x => x.Ders_id, x =>
            {
                x.Column("Ders_id");
                x.NotNullable(true);
            });
            ManyToOne(x => x.Ogretmen_id, x =>
            {
                x.Column("Ogretmen_id");
                x.NotNullable(true);
            });

        }
    }
}