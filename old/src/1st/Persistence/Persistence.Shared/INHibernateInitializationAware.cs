using NHibernate;

namespace Persistence.Shared
{
    public interface INHibernateInitializationAware
    {
        void Initialized(NHibernate.Cfg.Configuration configuration, ISessionFactory sessionFactory);
    }
}