using Model.Shared;

namespace Ics.Model
{
    public class RecipeableItem : DomainEntity
    {
        /// <summary>
        /// The name of this recipable item
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// The unit to measure this item within a recipe
        /// </summary>
        public virtual Unit RecipeUnit { get; set; }
    }

    public static class EditRecipeableItemExtensions
    {
        public static string GetRecipeableItemType(this RecipeableItem item)
        {
            if (item != null)
            {
                if (item is PurchaseItem)
                    return "I";
                if (item is ProductionItem)
                    return "P";
            }
            return null;
        }
    }
}