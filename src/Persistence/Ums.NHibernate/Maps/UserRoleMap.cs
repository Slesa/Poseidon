using FluentNHibernate.Mapping;
using Ums.Model;

namespace Ums.NHibernate.Maps
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
