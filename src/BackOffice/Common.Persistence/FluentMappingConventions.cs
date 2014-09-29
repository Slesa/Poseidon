using System;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;
using Poseidon.Common.Persistence.Contracts;

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

    internal static class StringExtensions
    {
        public static string Escape(this string instance)
        {
            return string.Format("`{0}`", instance);
        }
    }
}