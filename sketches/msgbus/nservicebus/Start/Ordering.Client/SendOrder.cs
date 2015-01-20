using System;
using NServiceBus;
using Ordering.Messages;

namespace Ordering.Client
{
    public class SendOrder : IWantToRunWhenBusStartsAndStops
    {
        public IBus Bus { get; set; }

        public void Start()
        {
            Console.WriteLine("Press <Enter> to send a message. To exit <CTRL>+c");

            for (;;)
            {
                var text = Console.ReadLine();
                if (string.IsNullOrEmpty(text)) break;

                if (text.ToLower().Equals("quit"))
                {
                    Bus.Send("Ordering.Server", new QuitMessage {Id = Guid.NewGuid()});
                    Environment.Exit(42);
                }
                var id = Guid.NewGuid();

                Bus.Send("Ordering.Server", new PlaceOrder {Product = text, Id = id});
                Console.WriteLine("Order placed with product='{0}' and id {1}", text, id);
            }
        }

        public void Stop()
        {
            
        }
    }
}