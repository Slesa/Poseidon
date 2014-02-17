using System;
using System.Collections.Generic;

namespace FrontEnd.app.cli
{
    class Program
    {
        static readonly IEnumerable<string> MainMenuItems = new[]
            {
                "Order", "Void", "Pay", "Change", "Tables", "Split", "Reports"
            };

        static void Main(string[] args)
        {
            Login();
            Console.ReadKey();
        }

        static void Login()
        {
            var waiter = new ManualInput("Waiter", 3).GetNumber();
            var choice = new MenuInput("Main", MainMenuItems).Select();
        }

        void MainMenu()
        {

        }
    }
}
