using System;
using System.Diagnostics;
using FluentNHibernate.Cfg;
using FluentNHibernate.Utils;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using Poseidon.Common.Persistence.Contracts;

namespace Poseidon.Common.Persistence
{
    public class HibernateSessionFactory : IHibernateSessionFactory
    {
        private static readonly object InitializationSynchronization = new object();
        private readonly IPersistenceConfiguration _persistenceConfiguration;
        private readonly IHibernatePersistenceModel _persistenceModel;
        private ISessionFactory _sessionFactory;

        public HibernateSessionFactory(IPersistenceConfiguration persistenceConfiguration, IHibernatePersistenceModel persistenceModel)
        {
            _persistenceConfiguration = persistenceConfiguration;
            _persistenceModel = persistenceModel;
        }

        ~HibernateSessionFactory()
        {
            Dispose(false);
        }

        public IHibernateInitializationAware[] Initializers
        {
            get;
            set;
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

        private ISessionFactory CreateSessionFactory()
        {
            var configuration = Fluently.Configure()
                .Database(_persistenceConfiguration.GetConfiguration)
                .Mappings(_persistenceModel.AddMappings);

            var actualConfiguration = configuration.BuildConfiguration();
            CreateDatabaseWhenDebug(configuration);

            _sessionFactory = configuration.BuildSessionFactory();
            if (Initializers != null)
                Initializers.Each(x => x.Initialized(actualConfiguration, _sessionFactory));

            return _sessionFactory;
        }

        [Conditional("DEBUG")]
        private static void CreateDatabaseWhenDebug(FluentConfiguration configuration)
        {
            if (configuration == null) throw new ArgumentNullException("configuration");
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