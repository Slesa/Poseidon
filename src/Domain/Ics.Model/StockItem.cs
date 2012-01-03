using Model.Shared;

namespace Ics.Model
{
    public class StockItem : DomainEntity
    {
        /// <summary>
        /// The stock, this stock item belongs to
        /// </summary>
        public virtual Stock Stock { get; set; }
        /// <summary>
        /// The quantity of this item, available in stock
        /// </summary>
        public virtual decimal Quantity { get; set; }
        /// <summary>
        /// The unit the item is measured in
        /// </summary>
        public virtual Unit Unit { get; set; }
        /// <summary>
        /// The recipeable item corresponding to the stock item
        /// </summary>
        public virtual RecipeableItem RecipeableItem { get; set; }

        public StockItem(decimal quantity, RecipeableItem recipeableItem)
        {
            Quantity = quantity;
            RecipeableItem = recipeableItem;
        }

        public StockItem()
        {
        }
    }
}