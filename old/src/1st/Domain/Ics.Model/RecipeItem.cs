using Model.Shared;

namespace Ics.Model
{
    public class RecipeItem : DomainEntity
    {
        /// <summary>
        /// The recipe this recipe item belongs to
        /// </summary>
        public virtual Recipe Recipe { get; set; }

        public virtual ProductionItem ProductionItem { get; set; }
        public virtual RecipeableItem RecipeableItem { get; set; }
        public virtual decimal Quantity { get; set; }
        public virtual Unit Unit { get; set; }

        public RecipeItem(decimal quantity, RecipeableItem recipeableItem)
        {
            Quantity = quantity;
            RecipeableItem = recipeableItem;
        }

        public RecipeItem()
        {
        }
    }
}