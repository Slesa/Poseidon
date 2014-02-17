using Pms.Business.Contracts;
using Pms.Business.Models;
using Pms.Model;
using Poseidon.Common.Persistence;

namespace Pms.Business.Services
{
    public class TerminalProvider : IProvideTerminals
    {
        public IDbConversation DbConversation { get; set; }
        public IProvideWorkbenches WorkbenchProvider { get; set; }

        public PmsTerminal ClaimTerminal(uint terminalId)
        {
            if (terminalId == 0) throw new InvalidTerminalIdException();

            var terminal = DbConversation.GetById<Terminal>(terminalId);
            if (terminal == null) throw new TerminalNotFoundException();

            return new PmsTerminal(WorkbenchProvider) {Terminal = terminal};
        }

        public void FreeTerminal(PmsTerminal terminal)
        {
            if(terminal==null) throw new InvalidTerminalException();
        }
    }

}