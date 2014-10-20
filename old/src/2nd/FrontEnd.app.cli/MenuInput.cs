using System;
using System.Collections.Generic;

namespace FrontEnd.app.cli
{
    public class MenuInput
    {
        readonly string _title;
        readonly IEnumerable<string> _items;

        public MenuInput(string title, IEnumerable<string> items)
        {
            _title = title;
            _items = items;
        }

        public uint Select()
        {
            var count = 1;
            Console.WriteLine("---[{0}]---", _title);
            foreach (var item in _items)
            {
                Console.WriteLine("[{0}] {1}", count++, item);
            }
            return new ManualInput("Your choice", 1).GetNumber();
        }
    }
}