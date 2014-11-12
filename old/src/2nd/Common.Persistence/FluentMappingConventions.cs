using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;

namespace Poseidon.Common.Persistence
{
    public class FluentMappingConventions : IMappingContributor
    {
        public void Apply(MappingConfiguration configuration)
        {
            var conventions = configuration.FluentMappings.Conventions;
            conventions.Add(ConventionBuilder
                                .Class
                                .Always(x => x.Table(Inflector.Inflector.Pluralize(x.EntityType.Name).Escape())));
        }
    }

    static class StringExtensions
    {
        public static string Escape(this string instance)
        {
            return String.Format("`{0}`", instance);
        }
    }
}