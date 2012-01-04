using FluentNHibernate.Cfg.Db;
using Persistence.Shared;

namespace NHibernate.Specs.Shared
{
    class SqLiteInMemoryDatabaseConfiguration : IPersistenceConfiguration
    {
        public IPersistenceConfigurer GetConfiguration()
        {
            return SQLiteConfiguration
                .Standard
                .InMemory()
                .ShowSql();
            //.ProxyFasctoryFactory
        }
    }
}