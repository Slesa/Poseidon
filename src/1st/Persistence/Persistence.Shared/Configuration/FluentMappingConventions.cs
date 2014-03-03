using System;
using System.ComponentModel.Composition;
using FluentNHibernate.Cfg;
using FluentNHibernate.Conventions.Helpers;

namespace Persistence.Shared.Configuration
{
    [Export(typeof(IMappingContributor))]
    public class FluentMappingConventions : IMappingContributor
    {
        public void Apply(MappingConfiguration configuration)
        {
            var conventions = configuration.FluentMappings.Conventions;
            //conventions.Add(ConventionBuilder
            //                    .Class.Always(
            //                        x => x.Table(Inflector.Net.Inflector.Pluralize(x.EntityType.Name).Escape())));
            conventions.Add(ConventionBuilder.Property.Always(x => x.Column(x.Property.Name)));
            conventions.Add(DefaultLazy.Always());
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