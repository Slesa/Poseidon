using System;

namespace Cafe.Contracts.Commands
{
    public class OpenTab
    {
        public Guid Id;
        public int TableNumber { get; set; }
        public string Waiter { get; set; }
    }
}
