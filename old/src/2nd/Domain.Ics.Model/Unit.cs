using Poseidon.Domain.Common;

namespace Poseidon.Domain.Ics.Model
{
    public class Unit : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual string Contraction { get; set; }
        public virtual UnitType UnitType { get; set; }
        public virtual Unit Parent { get; set; }
        public virtual decimal FactorToParent { get; set; }
        public virtual bool ForPurchase { get; set; }
        public virtual bool ForRecipe { get; set; }
    }
}