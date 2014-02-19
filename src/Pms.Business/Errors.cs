using System;

namespace Pms.Business
{
    public class InvalidTerminalIdException : Exception { }
    public class InvalidTerminalException : Exception { }
    public class TerminalNotFoundException : Exception { }

    public class InvalidWaiterIdException : Exception { }
    public class InvalidWorkbenchException : Exception { }
    public class WaiterNotFoundException : Exception { }

    public class InvalidTableIdException : Exception { }
    public class InvalidPartyException : Exception { }
    public class InvalidTableException : Exception { }

}