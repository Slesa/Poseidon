using System;
using System.Collections.Generic;

namespace Cafe.Contracts.Commands
{
    public class MarkDrinksServed
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
