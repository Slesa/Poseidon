using System.ComponentModel.Composition;
using FluentNHibernate.Cfg.Db;

namespace Persistence.Shared.Configuration
{
    [Export(typeof(IPersistenceConfiguration))]
    public class SqlServerPersistenceConfiguration : IPersistenceConfiguration
    {
        readonly string _connectionString;

        [ImportingConstructor]
        public SqlServerPersistenceConfiguration([Import("ConnectionString")]string connectionString)
        {
            _connectionString = connectionString;
        }

        protected bool ShowSql { get; set; }

        public IPersistenceConfigurer GetConfiguration()
        {
            var configuration = MsSqlConfiguration
                .MsSql2005
                .ConnectionString(c => c.Is(_connectionString))
                .AdoNetBatchSize(10)
                .UseReflectionOptimizer()
                .UseOuterJoin();
            if (ShowSql)
                configuration.ShowSql();
            return configuration;
        }
    }
}