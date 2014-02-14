using System;
using System.Collections.Generic;

namespace Cafe.Contracts.Events
{
    public class FoodServed
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
