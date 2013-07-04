using Poseidon.Domain.Common;

namespace Poseidon.Domain.Pms.Model
{
    public class Currency : DomainEntity
    {
        public virtual string Name { get; set; }
    }
}