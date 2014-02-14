using System;
using System.Collections.Generic;

namespace Cafe.Contracts.Commands
{
    public class MarkFoodServed
    {
        public Guid Id;
        public List<int> MenuNumbers;
    }
}
