using Model.Shared;

namespace Ics.Model
{
    public class Unit : DomainEntity
    {
        /// <summary>
        /// Name of the unit
        /// </summary>
        public virtual string Name { get; set; }
        /// <summary>
        /// Short name of the unit
        /// </summary>
        public virtual string Contraction { get; set; }
        /// <summary>
        /// The type of this unit, e.g. 'weight' or 'volume'
        /// </summary>
        public virtual UnitType UnitType { get; set; }
        /// <summary>
        /// The parent of this unit, if one exists
        /// </summary>
        public virtual Unit Parent { get; set; }
        /// <summary>
        /// Translation factor to the parent
        /// </summary>
        public virtual decimal FactorToParent { get; set; }
        /// <summary>
        /// Flag if this unit can be used for purchasing goods
        /// </summary>
        public virtual bool ForPurchase { get; set; }
        /// <summary>
        /// Flag if this unit can be used for recipes
        /// </summary>
        public virtual bool ForRecipe { get; set; }
    }
}