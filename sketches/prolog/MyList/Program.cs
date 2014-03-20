using Axiom.Runtime;
using Prolog.Assembly;

namespace MyList
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new PrologList();

            var a = new AbstractTerm();
            var b = new AbstractTerm();
            var c = new AbstractTerm();
            list.runme(a, b, c);

            System.Console.WriteLine(a);
            System.Console.WriteLine(b);
            System.Console.WriteLine(c);
            System.Console.ReadKey();
        }
    }
}
