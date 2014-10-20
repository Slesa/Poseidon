using NHibernate;

namespace Poseidon.Common.Persistence
{
    public interface IDomainQuery<out TResult>
    {
        TResult Execute(ISession session);
    }
}