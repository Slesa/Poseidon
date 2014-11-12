using Model.Shared;

namespace Ics.Model
{
    public class PurchaseFamily : DomainEntity
    {
        /// <summary>
        /// The name of the purchase family
        /// </summary>
        public virtual string Name { get; set; }
    }
}