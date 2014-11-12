using Poseidon.Domain.Common;

namespace Pms.Model
{
    public class Waiter : DomainEntity
    {
        public virtual string Name { get; set; }
        //public virtual User User { get; set; }
        public virtual WaiterTeam WaiterTeam { get; set; }
    }
}