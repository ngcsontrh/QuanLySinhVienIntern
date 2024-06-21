using ConsoleAppNHibernate.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNHibernate
{
    public static class NHibernateHelper
    {
        public static ISession OpenSession()
        {
            string connectionString = "Data Source=DESKTOP-47ECO45;Initial Catalog=qlsv;Integrated Security=True;TrustServerCertificate=True";
            var sessionFactory = Fluently.Configure()
                    .Database(MsSqlConfiguration
                        .MsSql2012
                        .ConnectionString(connectionString))
                    .Mappings(m => m.FluentMappings
                        .AddFromAssemblyOf<TeacherEntityMap>()
                        .AddFromAssemblyOf<ClassEntityMap>()
                        .AddFromAssemblyOf<StudentEntityMap>())
                    .BuildSessionFactory();

            return sessionFactory.OpenSession();
        }
    }

}
