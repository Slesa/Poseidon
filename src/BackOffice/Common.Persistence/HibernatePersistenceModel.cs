using System.Collections.Generic;
using Common.Persistence.Contracts;
using FluentNHibernate.Cfg;
using FluentNHibernate.Utils;
using Microsoft.Practices.Unity;

namespace Common.Persistence
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