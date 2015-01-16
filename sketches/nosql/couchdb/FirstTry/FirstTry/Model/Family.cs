using System.Collections.Generic;

namespace FirstTry.Model
{
    public class Family
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FamilyGroup { get; set; }

        public static List<Family> CreateFamilies()
        {
            var result = new List<Family>();
            for (int i = 1; i < 10; i++)
            {
                var family = new Family {Id = i, Name = "Family " + i, FamilyGroup = 1};
                result.Add(family);
            }
            return result;
        }
    }

}