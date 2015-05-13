using System;
using NServiceBus;
using Ordering.Messages;

namespace Ordering.Server
{
    public class QuitMessageHandler : IHandleMessages<QuitMessage>
    {
        public void Handle(QuitMessage message)
        {
            Environment.Exit(42);
        }
    }
}