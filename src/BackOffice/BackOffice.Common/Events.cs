using System;
using Microsoft.Practices.Prism.Events;
using Poseidon.BackOffice.Common.ViewModels;

namespace Poseidon.BackOffice.Common
{
    public class StatusBarClearEvent : CompositePresentationEvent<int>  { }
    public class StatusBarMessageEvent : CompositePresentationEvent<string> { }

    public class CurrentModuleChangedEvent : CompositePresentationEvent<Uri> { }
}
