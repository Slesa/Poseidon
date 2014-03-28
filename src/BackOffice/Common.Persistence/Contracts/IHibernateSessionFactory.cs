using System;
using NHibernate;

namespace Poseidon.Common.Persistence.Contracts
{
    public interface IHibernateSessionFactory : IDisposable
    {
        ISession CreateSession();
    }
}