using Poseidon.Domain.Common;

namespace Poseidon.Ums.Domain.Model
{
    public class Token : DomainEntity
    {
        public virtual string Key { get; set; }
        public virtual TokenType TokenType { get; set; }
    }
}