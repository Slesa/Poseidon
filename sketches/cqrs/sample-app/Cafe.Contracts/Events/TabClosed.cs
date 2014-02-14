using System;

namespace Cafe.Contracts.Events
{
    public class TabClosed
    {
        public Guid Id;
        public decimal AmountPaid;
        public decimal OrderValue;
        public decimal TipValue;
    }
}
