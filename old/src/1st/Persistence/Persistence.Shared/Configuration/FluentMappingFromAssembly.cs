using System.Reflection;
using FluentNHibernate.Cfg;

namespace Persistence.Shared.Configuration
{
    public class FluentMappingFromAssembly : IMappingContributor
    {
        readonly Assembly _assembly;

        public FluentMappingFromAssembly(string assembly)
        {
            _assembly = Assembly.LoadFrom(assembly);
        }

        public void Apply(MappingConfiguration configuration)
        {
            configuration.FluentMappings.AddFromAssembly(_assembly);
        }
    }
}