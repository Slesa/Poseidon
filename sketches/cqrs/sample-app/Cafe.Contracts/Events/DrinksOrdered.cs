using System;
using System.Collections.Generic;
using Cafe.Contracts.Models;

namespace Cafe.Contracts.Events
{
    public class DrinksOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
