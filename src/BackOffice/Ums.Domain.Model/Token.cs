using Poseidon.Domain.Common;

namespace Poseidon.Ums.Domain.Model
{
    public class Token : DomainEntity
    {
        public virtual string Data { get; set; }
        public virtual TokenType TokenType { get; set; }
    }
}