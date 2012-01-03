using Model.Shared;

namespace Ics.Model
{
    public class UnitType : DomainEntity
    {
        /// <summary>
        /// The name of this unit type
        /// </summary>
        public virtual string Name { get; set; }
    }
}
