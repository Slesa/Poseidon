﻿using Poseidon.Domain.Common;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Pms.Domain.Model
{
    public class Waiter : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual User User { get; set; }
        public virtual WaiterTeam WaiterTeam { get; set; }
    }
}