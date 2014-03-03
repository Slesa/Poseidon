using Microsoft.Practices.Prism.Events;

namespace Poseidon.BackOffice.Common
{
    public class StatusBarClearEvent : CompositePresentationEvent<int>  { }
    public class StatusBarMessageEvent : CompositePresentationEvent<string> { }
}
