using FluentNHibernate.Mapping;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Domain.Ums.Hibernate.Maps
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