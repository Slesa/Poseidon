using System.Collections.Generic;
using Model.Shared;

namespace Ums.Model
{
    public class User : DomainEntity
    {
        IList<UserToken> _userTokens = new List<UserToken>();

        public virtual string Name { get; set; }
        public virtual UserRole UserRole { get; set; }
        public virtual IEnumerable<UserToken> UserTokens
        {
            get { return _userTokens; }
        }

        public virtual void AddUserToken(UserToken userToken)
        {
            userToken.User = this;
            _userTokens.Add(userToken);
        }

        public virtual void RemoveUserToken(UserToken userToken)
        {
            _userTokens.Remove(userToken);
        }
    }
}