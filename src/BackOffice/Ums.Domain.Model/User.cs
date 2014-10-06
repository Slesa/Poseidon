using Poseidon.Domain.Common;

namespace Poseidon.Ums.Domain.Model
{
    public class User : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Password { get; set; }
        public virtual string Salt { get; set; }
        public virtual UserRole UserRole { get; set; }
    }
}