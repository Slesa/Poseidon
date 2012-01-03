using Model.Shared;

namespace Ums.Model
{
    public class UserRoleItem : DomainEntity
    {
        public virtual string Program { get; set; }
        public virtual string Module { get; set; }
        public virtual string Function { get; set; }
    }
}
