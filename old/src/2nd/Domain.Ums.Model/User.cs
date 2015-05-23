using Poseidon.Domain.Common;

namespace Poseidon.Domain.Ums.Model
{
    public class User : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}