using Poseidon.Domain.Common;

namespace Poseidon.Domain.Ums.Model
{
    public class UserToken : DomainEntity
    {
        public virtual User User { get; set; }
        public virtual Token Token { get; set; }
    }
}