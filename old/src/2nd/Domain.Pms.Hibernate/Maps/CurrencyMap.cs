﻿using FluentNHibernate.Mapping;
using Poseidon.Domain.Pms.Model;

namespace Poseidon.Domain.Pms.Hibernate.Maps
{
    public class CurrencyMap : ClassMap<Currency>
    {
        public CurrencyMap()
        {
            Id(d => d.Id).GeneratedBy.HiLo("10");

            Map(d => d.Name).Length(40);
            Map(d => d.Contraction).Length(10);
            Map(d => d.Symbol).Length(3);
            Map(d => d.Rate).Default("1.0");
            Map(d => d.DecimalChar);
            Map(d => d.DecimalPosition).Default("2");
            Map(d => d.ThousandChar);

            Version(d => d.Version);
        }
    }
}