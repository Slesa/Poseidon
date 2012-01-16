using System;
using System.ComponentModel.Composition;
using System.Diagnostics;
using FluentNHibernate.Cfg;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace Persistence.Shared
{
    [Export(typeof(INHibernateSessionFactory))]
    public class NHibernateSessionFactory : INHibernateSessionFactory
    {
        static object InitializationSynchronization = new object();
        ISessionFactory _sessionFactory;
        readonly IPersistenceConfiguration _persistenceConfiguration;
        INHibernatePersistenceModel _persistenceModel;

        [ImportingConstructor]
        public NHibernateSessionFactory(IPersistenceConfiguration persistenceConfiguration
            , INHibernatePersistenceModel persistenceModel)
        {
            _persistenceConfiguration = persistenceConfiguration;
            _persistenceModel = persistenceModel;
        }

        ~NHibernateSessionFactory()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool @explicit)
        {
            if (!@explicit) return;
            if (_sessionFactory == null) return;
            _sessionFactory.Dispose();
            _sessionFactory = null;
        }

        public ISession CreateSession()
        {
            if (_sessionFactory == null)
            {
                lock (InitializationSynchronization)
                {
                    if (_sessionFactory == null)
                        _sessionFactory = CreateSessionFactory();
                }
            }

            var session = _sessionFactory.OpenSession();
            session.FlushMode = FlushMode.Commit;
            return session;
        }

        ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(_persistenceConfiguration.GetConfiguration)
                .Mappings(_persistenceModel.AddMappings);

            CreateDatabaseWhenDebug(configuration);
            _sessionFactory = configuration.BuildSessionFactory();
            return _sessionFactory;
        }

        [Conditional("DEBUG")]
        static void CreateDatabaseWhenDebug(FluentConfiguration configuration)
        {
            if(configuration==null) throw new ArgumentNullException("configuration");
            configuration.ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Configure()
        {
            CreateSessionFactory();
        }
    }
}