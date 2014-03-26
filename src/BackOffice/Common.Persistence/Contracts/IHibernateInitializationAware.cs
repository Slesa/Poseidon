using NHibernate;

namespace Common.Persistence.Contracts
{
    public interface IHibernateInitializationAware
    {
        void Initialized(NHibernate.Cfg.Configuration configuration, ISessionFactory sessionFactory);
    }
}