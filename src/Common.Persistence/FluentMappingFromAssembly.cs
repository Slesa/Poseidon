using System.Reflection;
using FluentNHibernate.Cfg;

namespace Poseidon.Common.Persistence
{
    public class FluentMappingFromAssembly
    {
        Assembly _assembly;

        public FluentMappingFromAssembly WithAssembly(string assemblyName)
        {
            _assembly = Assembly.LoadFrom(assemblyName);
            return this;
        }

        public void ApplyMappings(MappingConfiguration configuration)
        {
            if(_assembly!=null) configuration.FluentMappings.AddFromAssembly(_assembly);
        }
    }
}