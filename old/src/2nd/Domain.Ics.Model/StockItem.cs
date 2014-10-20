using Poseidon.Domain.Common;

namespace Poseidon.Domain.Ics.Model
{
    public class StockItem : DomainEntity
    {
        public virtual Stock Stock { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual Unit Unit { get; set; }
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