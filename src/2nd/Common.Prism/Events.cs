using Microsoft.Practices.Prism.Events;

namespace Poseidon.Common.Prism
{
    public class ClearMessageEvent : CompositePresentationEvent<int> { }
    public class ShowMessageEvent : CompositePresentationEvent<string> { }
}