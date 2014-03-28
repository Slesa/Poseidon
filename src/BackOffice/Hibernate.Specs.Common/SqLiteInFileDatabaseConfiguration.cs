using FluentNHibernate.Cfg.Db;
using Poseidon.Common.Persistence.Contracts;

namespace Poseidon.Hibernate.Specs.Common
{
    public class SqLiteInFileDatabaseConfiguration : IPersistenceConfiguration
    {
        public IPersistenceConfigurer GetConfiguration()
        {
            return SQLiteConfiguration
                .Standard
                .UsingFile("testonly.db")
                .ShowSql();
        }
    }
}