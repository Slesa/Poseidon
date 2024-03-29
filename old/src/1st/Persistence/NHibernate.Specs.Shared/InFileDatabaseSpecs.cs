﻿using System.Data.SQLite;
using System.Diagnostics;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Machine.Specifications;
using NHibernate.Tool.hbm2ddl;

namespace NHibernate.Specs.Shared
{
    [Subject(typeof(SQLiteConfiguration))]
    public class InFileDatabaseSpecs<TMappingAssembly>
    {
        Establish context = () =>
            {
                //NHibernateProfiler.Initialize();

                var forceSqlLiteReference = typeof (SQLiteException) != null;
                Trace.Assert(forceSqlLiteReference);
                Debug.Assert(forceSqlLiteReference);

                var configuration = Fluently.Configure()
                    .Database(new SqLiteInFileDatabaseConfiguration().GetConfiguration())
                    .Mappings(x => x.FluentMappings.AddFromAssemblyOf<TMappingAssembly>());

                /*var actualConfiguration =*/ configuration.BuildConfiguration();
                configuration.ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true));

                _sessionFactory = configuration.BuildSessionFactory();
            };

        Cleanup teardown = () =>
            {
                //NHibernateProfiler.Stop();
            };

        protected static ISession CreateSession()
        {
            var session = _sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            return session;
        }

        static ISessionFactory _sessionFactory;
    }
}