using Poseidon.Domain.Common;

namespace Poseidon.Domain.Ums.Model
{
    public class Token : DomainEntity
    {
        public virtual string Key { get; set; }
        public virtual TokenType TokenType { get; set; }
    }
}