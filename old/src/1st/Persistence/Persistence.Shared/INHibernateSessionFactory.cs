using System;
using NHibernate;

namespace Persistence.Shared
{
    public interface INHibernateSessionFactory : IDisposable
    {
        ISession CreateSession();
    }
}