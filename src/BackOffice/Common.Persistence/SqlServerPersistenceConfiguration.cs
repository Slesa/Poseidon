using Common.Persistence.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Common.Persistence
{
    public class SqlServerPersistenceConfiguration : IPersistenceConfiguration
    {
        readonly string _connectionString;
        public bool ShowSql { get; set; }

        public SqlServerPersistenceConfiguration(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IPersistenceConfigurer GetConfiguration()
        {
            var configuration = MsSqlConfiguration
                .MsSql2008
                .ConnectionString(c => c.Is(_connectionString))
                //.ProxyFactoryFactory(typeof(ProxyFactoryFactory).AssemblyQualifiedName)
                .AdoNetBatchSize(10)
                .UseReflectionOptimizer()
                .UseOuterJoin();

            if (ShowSql)
            {
                configuration.ShowSql();
            }

            return configuration;
        }
    }
}