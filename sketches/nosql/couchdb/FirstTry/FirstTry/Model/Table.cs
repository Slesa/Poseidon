using System.Collections.Generic;
using LoveSeat.Interfaces;

namespace FirstTry.Model
{
    public class Table : IBaseObject
    {
        public Table()
        {
            Families = new List<Family>();
            FamilyGroups = new List<FamilyGroup>();
        }

        public List<Family> Families { get; private set; }
        public List<FamilyGroup> FamilyGroups { get; private set; }

        public string Id { get; set; }
        public string Rev { get; set; }
        public string Type { get; private set; }
    }
}