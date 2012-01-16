using System.ComponentModel.Composition;
using Persistence.Shared;
using Persistence.Shared.Configuration;
using Pms.NHibernate.Maps;

namespace Pms.NHibernate
{
    [Export(typeof(IMappingContributor))]
    public class PmsModelContributor : FluentMappingFromAssembly
    {
        public PmsModelContributor()
            : base(typeof(SalesItemMap).Assembly.CodeBase)
        {}
    }
}