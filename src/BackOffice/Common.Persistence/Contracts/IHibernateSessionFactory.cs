using System;
using NHibernate;

namespace Common.Persistence.Contracts
{
    public interface IHibernateSessionFactory : IDisposable
    {
        ISession CreateSession();
    }
}