namespace Ics.Model
{
    public class PurchaseItem : RecipeableItem
    {
        /// <summary>
        /// The purchase family this item belongs to
        /// </summary>
        public virtual PurchaseFamily PurchaseFamily { get; set; }
        /// <summary>
        /// The unit to measure this item when purchasing
        /// </summary>
        public virtual Unit PurchaseUnit { get; set; }
    }
}