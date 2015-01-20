using System;
using NServiceBus;

namespace Ordering.Messages
{
    public class QuitMessage : ICommand
    {
        public Guid Id { get; set; }
    }
}