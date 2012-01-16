using System;
using System.ComponentModel.Composition;
using NHibernate;

namespace Persistence.Shared
{
    [Export(typeof(IDbConversation))]
    public class DbConversation : IDbConversation
    {
        readonly ISession _session;

        [ImportingConstructor]
        public DbConversation(INHibernateSessionFactory sessionFactory)
        {
            _session = sessionFactory.CreateSession();
        }

        public void Dispose()
        {
            if (_session != null)
                _session.Dispose();
        }

        public TResult Query<TResult>(IDomainQuery<TResult> query)
        {
            return query.Execute(_session);
        }

        public void UsingTransaction(Action action)
        {
            using (var transaction=_session.BeginTransaction())
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
    }
}