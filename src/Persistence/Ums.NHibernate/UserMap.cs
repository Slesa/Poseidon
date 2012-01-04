using FluentNHibernate.Mapping;
using Ums.Model;

namespace Ums.NHibernate
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);

            Version(d => d.Version);
        }
    }
}