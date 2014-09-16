using System;
using Microsoft.Practices.Prism.PubSubEvents;

namespace Poseidon.BackOffice.Common
{
    public class StatusBarClearEvent : PubSubEvent<int>  { }
    public class StatusBarMessageEvent : PubSubEvent<string> { }

    public class CurrentModuleUriChangedEvent : PubSubEvent<Uri> { }
}
