using Axiom.Runtime;
using Prolog.Assembly;

namespace MyPeg
{
    class Program
    {
        static void Main(string[] args)
        {
            var peg = new PrologPeg();
            var result = new AbstractTerm();
            peg.solve(result);

            System.Console.WriteLine(result);
            System.Console.ReadKey();
        }
    }
}
