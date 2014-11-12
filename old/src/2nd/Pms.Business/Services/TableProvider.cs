using Pms.Business.Contracts;
using Pms.Business.Models;

namespace Pms.Business.Services
{
    public class TableProvider : IProvideTable
    {
        public PmsTable OpenTable(uint tableId, uint party=1)
        {
            if(tableId==0) throw new InvalidTableIdException();
            if(party==0) throw new InvalidPartyException();

            return new PmsTable(tableId, party);
        }

        public void CloseTable(PmsTable table)
        {
            if(table==null) throw new InvalidTableException();
        }
    }
}