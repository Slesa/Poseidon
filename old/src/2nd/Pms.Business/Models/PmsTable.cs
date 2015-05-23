namespace Pms.Business.Models
{
    public class PmsTable
    {
        public PmsTable(uint tableId, uint party)
        {
            TableId = tableId;
            Party = party;
        }

        public uint TableId { get; set; }
        public uint Party { get; set; }
    }
}