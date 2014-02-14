using System;
using System.Collections.Generic;

namespace Events.Cafe
{
    public class DrinksOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
