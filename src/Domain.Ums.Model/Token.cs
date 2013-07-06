using Poseidon.Domain.Common;

namespace Domain.Ums.Model
{
    public class Token : DomainEntity
    {
        public virtual string Key { get; set; }
        public virtual int Type { get; set; }
    }
}