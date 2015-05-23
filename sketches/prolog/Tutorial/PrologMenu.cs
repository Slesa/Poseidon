using System;
using System.Collections.Generic;

namespace Tutorial
{
    public class MenuItem
    {
        public string Title { get; set; }
        public string FileName { get; set; }
        public string QueryHint { get; set; }
    }

    public class PrologMenu
    {
        readonly MenuItem[] _menuItems;

        public PrologMenu(List<MenuItem> menuItems)
        {
            _menuItems = menuItems.ToArray();
        }

        public MenuItem Handle()
        {
            var index = 0;
            Console.WriteLine("{0}) Quit", index++);

            foreach (var item in _menuItems)
            {
                Console.WriteLine("{0}) {1}", index++, item.Title);
            }
            Console.Write("Choice: ");
            while (true)
            {
                var choice = Console.ReadLine();
                int i;
                if (!int.TryParse(choice, out i)) continue;
                
                return i == 0 ? null : _menuItems[i-1];
            }
        }
    }
}