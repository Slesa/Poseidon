using Model.Shared;

namespace Pms.Model.Entities
{
    public class SalesFamily : DomainEntity
    {
        public virtual string Name { get; set; }
        public virtual SalesFamilyGroup SalesFamilyGroup { get; set; }
    }
}