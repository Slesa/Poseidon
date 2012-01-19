using System.ComponentModel.Composition;
using System.Diagnostics;
using HibernatingRhinos.Profiler.Appender.NHibernate;
using NHibernate;

namespace Persistence.Shared.Configuration
{
    [Export(typeof(INHibernateInitializationAware))]
    public class NhProfilerInitializer : INHibernateInitializationAware
    {
        public bool Enabled { get; set; }

        public NhProfilerInitializer()
        {
            EnableProfiler();
        }

        [Conditional("DEBUG")]
        void EnableProfiler()
        {
            Enabled = true;
        }

        public void Initialized(NHibernate.Cfg.Configuration configuration, ISessionFactory sessionFactory)
        {
            if(!Enabled)
                return;
            NHibernateProfiler.Initialize();
        }
    }
}