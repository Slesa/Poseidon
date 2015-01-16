using FirstTry.Model;
using LoveSeat;

namespace FirstTry
{
    // https://github.com/soitgoes/LoveSeat
    class Program
    {
        static void Main(string[] args)
        {

            var ccAdmin = new CouchClient("localhost", 5984, null, null, false, AuthenticationType.Cookie);

            var dbName = "firsttry";
            if (!ccAdmin.HasDatabase(dbName))
            {
                ccAdmin.CreateDatabase(dbName);
            }


            var table = new Table {Id = "5"};
            table.Families.AddRange(Family.CreateFamilies());
            table.FamilyGroups.AddRange(FamilyGroup.CreateFamilyGroups());
            var doc = new Document<Table>(table);

            var db = ccAdmin.GetDatabase(dbName);
            db.SetDefaultDesignDoc("docs"); 

            db.SaveDocument(doc);
        }
    }
}
