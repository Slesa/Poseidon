using System;

namespace StateBasedNavigation.Infrastructure
{
    public class OperationResult : IOperationResult
    {
        public Exception Error { get; protected internal set; }
    }
}