using Poseidon.Domain.Common;

namespace Poseidon.Ums.Domain.Model
{
    public class UserToken : DomainEntity
    {
        public virtual User User { get; set; }
        public virtual Token Token { get; set; }
    }
}