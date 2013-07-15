using FluentNHibernate.Mapping;
using Poseidon.Domain.Ums.Model;

namespace Poseidon.Domain.Ums.Hibernate.Maps
{
    public class TokenMap : ClassMap<Token>
    {
        public TokenMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Key).Length(40);
            References(d => d.TokenType).Not.Nullable();

            Version(d => d.Version);
        }
    }
}