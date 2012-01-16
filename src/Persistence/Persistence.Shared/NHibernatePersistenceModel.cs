using System;
using System.ComponentModel.Composition;
using FluentNHibernate.Cfg;
using FluentNHibernate.Utils;

namespace Persistence.Shared
{
    [Export(typeof(INHibernatePersistenceModel))]
    public class NHibernatePersistenceModel : INHibernatePersistenceModel
    {
        [ImportMany]
        public IMappingContributor[] MappingContributors { get; set; }

        public void AddMappings(MappingConfiguration configuration)
        {
            MappingContributors.Each(x => x.Apply(configuration));
        }
    }
}