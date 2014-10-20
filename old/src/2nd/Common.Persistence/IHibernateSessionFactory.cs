using System;
using NHibernate;

namespace Poseidon.Common.Persistence
{
    public interface IHibernateSessionFactory : IDisposable
    {
        ISession CreateSession();
    }
}