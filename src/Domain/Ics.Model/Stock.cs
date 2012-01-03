using System.Collections.Generic;
using Model.Shared;

namespace Ics.Model
{
    public class Stock : DomainEntity
    {
        readonly IList<StockItem> _stockItems = new List<StockItem>();

        /// <summary>
        /// The name of this stock
        /// </summary>
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

        public virtual void RemoveStockItems(StockItem stockItem)
        {
            _stockItems.Remove(stockItem);
        }
    }
}