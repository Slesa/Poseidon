namespace Cafe.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintMainMenu();
        }

        static void PrintMainMenu()
        {
            System.Console.WriteLine("[1] Open Table");
            System.Console.WriteLine("[2] List Tables");
            System.Console.WriteLine("[3] Change Waiter");
        }
    }
}
