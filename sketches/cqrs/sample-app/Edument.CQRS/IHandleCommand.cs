using System;
using System.Collections;

namespace Edument.CQRS
{
    public interface IHandleCommand<TCommand, TAggregate>
    {
        IEnumerable Handle(Func<Guid, TAggregate> al, TCommand c);
    }
}
