using Eogrenme.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Mapping.ByCode;
using Rebus.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using static Eogrenme.Models.Bolum_Ogretmen_Dersler;
using static Eogrenme.Models.Dersler;

namespace Eogrenme
{
    public static class Database
    {
        private const string SessionKey = "Eogrenme.Database.SessionKey";
        private static ISessionFactory _sessionFactory;

        public static ISession Session
        {
            get
            {
                return (ISession)HttpContext.Current.Items[SessionKey];
            }
        }

        public static void Configure()
        {
            var config = new Configuration();
            var mapper = new ModelMapper();
            mapper.AddMapping<KisilerMap>();
            mapper.AddMapping<DerslerMap>();
            mapper.AddMapping<RolesMap>();
            mapper.AddMapping<BolumlerMap>();
            mapper.AddMapping<Bolum_Ogrenci_DerslerMap>();
            mapper.AddMapping<Bolum_Ogretmen_DerslerMap>();
            mapper.AddMapping<PdfMap>();
            mapper.AddMapping<OylamaMap>();
            mapper.AddMapping<KayıtTalepMap>();
            mapper.AddMapping<OgrencioyMap>();

            //mapper.AddMapping<Kisiler_DerslerMap>();
            config.AddMapping(mapper.CompileMappingForAllExplicitlyAddedEntities());

            config.Configure();
            _sessionFactory = config.BuildSessionFactory();
        }

        public static void OpenSession()
        {
            HttpContext.Current.Items[SessionKey] = _sessionFactory.OpenSession();
        }
        public static void CloseSession()
        {
            var session = HttpContext.Current.Items[SessionKey] as ISession;
            if (session != null)
                session.Close();
            HttpContext.Current.Items.Remove(SessionKey);
        }

    }
}