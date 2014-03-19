using Axiom.Runtime;
using Prolog.Assembly;

namespace FamilyApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Family familyDB = new Family();
            
            if(familyDB.son("jack", "tom"))
                System.Console.WriteLine("Yeah!");

            System.Console.WriteLine("Who is the father of john? ");

            AbstractTerm f = new AbstractTerm();
            familyDB.father(f, "john");

            System.Console.WriteLine(f);
        }
    }
}
