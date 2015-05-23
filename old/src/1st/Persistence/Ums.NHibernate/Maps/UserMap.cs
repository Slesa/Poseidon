using FluentNHibernate.Mapping;
using Ums.Model;

namespace Ums.NHibernate.Maps
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            References(d => d.UserRole).Not.Nullable();

            Version(d => d.Version);
        }
    }
}