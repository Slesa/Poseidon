using Common.Persistence.Contracts;
using FluentNHibernate.Cfg.Db;

namespace Hibernate.Specs.Common
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