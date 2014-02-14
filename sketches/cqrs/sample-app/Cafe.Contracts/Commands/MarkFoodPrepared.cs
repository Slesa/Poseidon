using System;
using System.Collections.Generic;

namespace Cafe.Contracts.Commands
{
    public class MarkFoodPrepared
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
