using NHibernate;

namespace Common.Persistence.Contracts
{
    public interface IDomainQuery<out TResult>
    {
        TResult Execute(ISession session);
    }
}