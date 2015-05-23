using FluentNHibernate.Mapping;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Maps
{
    public class UserMap : ClassMap<User>
    {
         public UserMap()
         {
             Id(d => d.Id).GeneratedBy.HiLo("10");

             Map(d => d.Name).Length(40);
             Map(d => d.Password).Length(40);
             Map(d => d.Salt).Length(40);
             References(d => d.UserRole).Not.Nullable();

             Version(d => d.Version);
         }
    }
}