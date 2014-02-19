using NHibernate;

namespace Poseidon.Common.Persistence
{
    public interface IHibernateInitializationAware
    {
        void Initialized(NHibernate.Cfg.Configuration configuration, ISessionFactory sessionFactory); 
    }
}