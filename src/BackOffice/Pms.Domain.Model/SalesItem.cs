using Poseidon.Domain.Common;

namespace Poseidon.Pms.Domain.Model
{
    public class SalesItem : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamily SalesFamily { get; set; }
    }
}