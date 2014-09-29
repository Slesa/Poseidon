using System;
using NHibernate;
using Poseidon.Common.Persistence.Contracts;

namespace Poseidon.Common.Persistence
{
    public class DbConversation : IDbConversation
    {
        private readonly ISession _session;

        public DbConversation(IHibernateSessionFactory sessionFactory)
        {
            _session = sessionFactory.CreateSession();
        }

        public TResult Query<TResult>(IDomainQuery<TResult> query)
        {
            return query.Execute(_session);
        }

        public void UsingTransaction(Action action)
        {
            using (var transaction = _session.BeginTransaction())
            {
                try
                {
                    action();
                    transaction.Commit();
                }
                catch (Exception)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }

        public TResult GetById<TResult>(object key)
        {
            return _session.Load<TResult>(key);
        }

        public void Insert(object instance)
        {
            _session.SaveOrUpdate(instance);
        }

        public void Remove(object instance)
        {
            _session.Delete(instance);
        }

        public void Dispose()
        {
            if (_session != null)
                _session.Dispose();
        }
    }
}