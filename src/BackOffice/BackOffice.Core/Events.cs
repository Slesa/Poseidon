namespace BackOffice.Core
{
    public class StatusBarMessageEvent
    {
        public StatusBarMessageEvent(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }

    public class StatusBarClearEvent { }
}