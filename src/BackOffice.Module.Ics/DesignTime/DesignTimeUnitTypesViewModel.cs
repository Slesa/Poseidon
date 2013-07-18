using System;
using System.Collections.Generic;
using System.Windows.Data;
using Poseidon.Domain.Ics.Model;

namespace Poseidon.BackOffice.Module.Ics.DesignTime
{
    public class DesignTimeUnitTypesViewModel
    {
        public IEnumerable<UnitType> UnitTypes
        {
            get
            {
                var ds = new XmlDataProvider();
                ds.Source = new Uri("/DesignTime/DesignTimeUnitTypes.xml");
                var result = ds.Data;
                return result as IEnumerable<UnitType>;
            }
        }
    }
}