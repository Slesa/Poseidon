using System;
using System.Collections.Generic;

namespace Cafe.Contracts.Events
{
    public class DrinksServed
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
