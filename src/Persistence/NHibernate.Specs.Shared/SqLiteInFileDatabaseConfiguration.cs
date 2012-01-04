using FluentNHibernate.Cfg.Db;
using Persistence.Shared;

namespace NHibernate.Specs.Shared
{
    class SqLiteInFileDatabaseConfiguration : IPersistenceConfiguration
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