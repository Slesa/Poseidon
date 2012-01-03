using Model.Shared;

namespace Ums.Model
{
    public class Token : DomainEntity
    {
        public virtual string Key { get; set; }
        public virtual int Type { get; set; }
    }
}