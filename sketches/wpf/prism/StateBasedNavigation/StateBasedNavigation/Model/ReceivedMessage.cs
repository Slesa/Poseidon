using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace StateBasedNavigation.Model
{
    public class ReceivedMessage : Notification
    {
        public ReceivedMessage(Contact contact, string message)
        {
            Contact = contact;
            Message = message;
        }

        public Contact Contact { get; private set; }
        public string Message { get; private set; }
    }
}