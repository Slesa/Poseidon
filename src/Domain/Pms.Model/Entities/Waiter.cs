using Model.Shared;

namespace Pms.Model.Entities
{
    public class Waiter : DomainEntity
    {
        public virtual WaiterTeam WaiterTeam { get; set; }
    }
}