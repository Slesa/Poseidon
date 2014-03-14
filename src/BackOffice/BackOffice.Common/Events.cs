using System;
using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;

namespace Poseidon.BackOffice.Common
{
    public class StatusBarClearEvent : CompositePresentationEvent<int>  { }
    public class StatusBarMessageEvent : CompositePresentationEvent<string> { }

    public class CurrentModuleUriChangedEvent : CompositePresentationEvent<Uri> { }
    public class CurrentSearchTextChangedEvent : CompositePresentationEvent<IList<string>> { }
}
