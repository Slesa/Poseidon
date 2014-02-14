using System;
using System.Collections.Generic;

namespace Cafe.Contracts.Events
{
    public class FoodPrepared
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
