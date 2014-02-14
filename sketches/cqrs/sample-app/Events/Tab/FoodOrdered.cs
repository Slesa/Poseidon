using System;
using System.Collections.Generic;

namespace Events.Cafe
{
    public class FoodOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
