using System;

namespace Cafe.Contracts.Events
{
    public class TabOpened
    {
        public Guid Id;
        public int TableNumber;
        public string Waiter;
    }
}
