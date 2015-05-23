namespace Poseidon.Domain.Ics.Model
{
    public class PurchaseItem : RecipeableItem
    {
        public virtual PurchaseFamily PurchaseFamily { get; set; }
        public virtual Unit PurchaseUnit { get; set; }
    }
}