
using System.Collections.Generic;

namespace Tutorial
{
    class Program
    {
        static readonly List<MenuItem> MainMenu = new List<MenuItem>
            {
                new MenuItem {Title = "Food", FileName = "prolog/food.pl", QueryHint = "food_flavor(X, Y)"}
            };

        static void Main(string[] args)
        {
            var menu = new PrologMenu(MainMenu);

            while (true)
            {
                var menuItem = menu.Handle();
                if (menuItem == null) return;

                var runner = new PrologRun(menuItem.FileName, menuItem.QueryHint);
                runner.Run();
            }



            /*
            var intro = new PrologIntro();

            var A = new AbstractTerm();
            intro.likes("john", A);
            System.Console.WriteLine(A);

            var B = new AbstractTerm();
            var C = new AbstractTerm();
            bool ret;
            do
            {
                ret = intro.likes(B, C);
                System.Console.WriteLine("{0} likes {1}", B, C);
                if(intro.More) intro.Redo();
            } while (ret);
*/
/*
            while (intro.More)
            {
                var x = new AbstractTerm();
                var y = new AbstractTerm();
                intro.Redo();
                ret = intro.likes(x, y);
                System.Console.WriteLine("{0} likes {1}", x, y);

            } 
*/
            System.Console.ReadKey();
        }
    }
}
