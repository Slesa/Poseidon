using System;
using System.Collections.Generic;
using Cafe.Contracts.Models;

namespace Cafe.Contracts.Events
{
    public class FoodOrdered
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
