using System;
using System.Collections.Generic;
using Cafe.Contracts.Models;

namespace Cafe.Contracts.Commands
{
    public class PlaceOrder
    {
        public Guid Id;
        public List<OrderedItem> Items;
    }
}
