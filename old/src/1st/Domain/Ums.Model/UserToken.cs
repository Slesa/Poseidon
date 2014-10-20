using Model.Shared;

namespace Ums.Model
{
    public class UserToken : DomainEntity
    {
        public virtual User User { get; set; }
        public virtual Token Token { get; set; }
    }
}