using NHibernate;

namespace Poseidon.Common.Persistence.Contracts
{
    public interface IDomainQuery<out TResult>
    {
        TResult Execute(ISession session);
    }
}