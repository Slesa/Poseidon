using NHibernate;

namespace Persistence.Shared
{
    public interface IDomainQuery<out TResult>
    {
        TResult Execute(ISession session);
    }
}