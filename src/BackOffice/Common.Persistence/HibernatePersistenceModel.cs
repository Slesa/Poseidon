using System.Collections.Generic;
using FluentNHibernate.Cfg;
using FluentNHibernate.Utils;
using Microsoft.Practices.Unity;
using Poseidon.Common.Persistence.Contracts;

namespace Poseidon.Common.Persistence
{
    public class HibernatePersistenceModel : IHibernatePersistenceModel
    {
        public IEnumerable<IMappingContributor> MappingContributors { get; set; }

        public HibernatePersistenceModel(IUnityContainer container)
        {
            MappingContributors = container.ResolveAll<IMappingContributor>();
        }

        public void AddMappings(MappingConfiguration configuration)
        {
            if (MappingContributors!=null) MappingContributors.Each(x => x.Apply(configuration));
        }
    }
}