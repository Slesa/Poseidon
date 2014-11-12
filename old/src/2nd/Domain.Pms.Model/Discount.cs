using Poseidon.Domain.Common;

namespace Poseidon.Domain.Pms.Model
{
    public class Discount : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual decimal Rate { get; set; }
        public virtual bool IsAbsolute { get; set; }
        public virtual bool UseForSale { get; set; }
        public virtual bool UseForOrders { get; set; }
    }
}