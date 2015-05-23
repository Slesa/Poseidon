using System;

namespace StateBasedNavigation.Infrastructure
{
    public interface IOperationResult
    {
        Exception Error { get; }
    }
}