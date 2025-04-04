﻿using System.Collections.Generic;
using Poseidon.Domain.Common;

namespace Poseidon.Domain.Ics.Model
{
    public class Stock : DomainEntity
    {
        readonly IList<StockItem> _stockItems = new List<StockItem>();

        public virtual string Name { get; set; }
        public virtual bool IsMainStock { get; set; }

        public virtual IEnumerable<StockItem> StockItems
        {
            get { return _stockItems; }
        }

        public virtual void AddStockItem(StockItem stockItem)
        {
            stockItem.Stock = this;
            _stockItems.Add(stockItem);
        }

        public virtual void RemoveStockItem(StockItem stockItem)
        {
            _stockItems.Remove(stockItem);
        }
    }
}