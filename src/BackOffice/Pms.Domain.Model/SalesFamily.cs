using Poseidon.Domain.Common;

namespace Poseidon.Pms.Domain.Model
{
    public class SalesFamily : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamilyGroup SalesFamilyGroup { get; set; }
    }
}