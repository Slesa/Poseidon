using FluentNHibernate.Mapping;
using Poseidon.Domain.Ums.Model;

namespace Poseidon.Domain.Ums.Hibernate.Maps
{
    public class TokenTypeMap : ClassMap<TokenType>
    {
        public TokenTypeMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);

            Version(d => d.Version);
        }
    }
}