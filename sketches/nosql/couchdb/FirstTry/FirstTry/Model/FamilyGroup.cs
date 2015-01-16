using System.Collections.Generic;

namespace FirstTry.Model
{
    public class FamilyGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static List<FamilyGroup> CreateFamilyGroups()
        {
            var result = new List<FamilyGroup>();
            for (int i = 1; i < 10; i++)
            {
                var familyGroup = new FamilyGroup { Id = i, Name = "Family " + i };
                result.Add(familyGroup);
            }
            return result;
        }
    }
}