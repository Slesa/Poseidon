namespace Poseidon.BackOffice.Core.Events
{
    public class StatusBarMessageEvent
    {
        public StatusBarMessageEvent(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}