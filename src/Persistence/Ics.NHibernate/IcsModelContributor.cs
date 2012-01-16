using System.ComponentModel.Composition;
using Ics.NHibernate.Maps;
using Persistence.Shared;
using Persistence.Shared.Configuration;

namespace Ics.NHibernate
{
    [Export(typeof(IMappingContributor))]
    public class IcsModelContributor : FluentMappingFromAssembly
    {
        public IcsModelContributor()
            : base(typeof(UnitTypeMap).Assembly.CodeBase)
        {}
    }
}