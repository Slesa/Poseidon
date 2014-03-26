using Common.Persistence.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Hibernate.Specs.Common
{
    public class SqLiteInMemoryDatabaseConfiguration : IPersistenceConfiguration
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