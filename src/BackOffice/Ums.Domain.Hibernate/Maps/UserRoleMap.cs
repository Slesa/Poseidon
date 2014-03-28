using FluentNHibernate.Mapping;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Maps
{
    public class UserRoleMap : ClassMap<UserRole>
    {
         public UserRoleMap()
         {
             Id(d => d.Id).GeneratedBy.HiLo("10");

             Map(d => d.Name).Length(40);

             Version(d => d.Version);
         }
    }
}