using FluentNHibernate.Mapping;
using Poseidon.Ums.Domain.Model;

namespace Poseidon.Ums.Domain.Hibernate.Maps
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