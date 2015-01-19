using NServiceBus;

namespace Ordering.Messages
{
    public class QuitMessage : ICommand
    {
        public IBus Bus { get; set; }
    }
}