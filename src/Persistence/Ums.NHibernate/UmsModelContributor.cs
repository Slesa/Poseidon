using System.ComponentModel.Composition;
using Persistence.Shared;
using Persistence.Shared.Configuration;
using Ums.NHibernate.Maps;

namespace Ums.NHibernate
{
    [Export(typeof(IMappingContributor))]
    public class UmsModelContributor : FluentMappingFromAssembly
    {
        public UmsModelContributor() 
            : base(typeof(UserMap).Assembly.CodeBase)
        {}
    }
}