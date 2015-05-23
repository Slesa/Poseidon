using Pms.Business.Contracts;
using Pms.Business.Models;
using Pms.Model;
using Poseidon.Common.Persistence;

namespace Pms.Business.Services
{
    public class WorkbenchProvider : IProvideWorkbenches
    {
        public IDbConversation DbConversation { get; set; }
        public IProvideTable TableProvider { get; set; }

        public PmsWorkbench ClaimWorkbench(uint waiterId)
        {
            if(waiterId==0) throw new InvalidWaiterIdException();

            var waiter = DbConversation.GetById<Waiter>(waiterId);
            if (waiter == null) throw new WaiterNotFoundException();

            return new PmsWorkbench(TableProvider) {Waiter = waiter};
        }

        public void FreeWorkbench(PmsWorkbench workbench)
        {
            if(workbench==null) throw new InvalidWorkbenchException();
        }
    }
}