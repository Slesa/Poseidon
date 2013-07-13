using FluentNHibernate.Cfg;
using FluentNHibernate.Utils;

namespace Poseidon.Common.Persistence
{
    public class HibernatePersistenceModel : IHibernatePersistenceModel
    {
        public IMappingContributor[] MappingContributors { get; set; }

        public void AddMappings(MappingConfiguration configuration)
        {
            MappingContributors.Each(x => x.Apply(configuration));
        }
    }
}