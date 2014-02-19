using FluentNHibernate.Mapping;
using Ums.Model;

namespace Ums.NHibernate.Maps
{
    public class TokenMap : ClassMap<Token>
    {
        public TokenMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Key).Length(40);
            Map(d => d.Type);

            Version(d => d.Version);
        }
    }
}