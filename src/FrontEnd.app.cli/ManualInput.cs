using System;

namespace FrontEnd.app.cli
{
    public class ManualInput
    {
        readonly string _title;
        readonly int _maxLength;
        readonly int _cursorLeft;
        readonly int _cursorTop;

        public ManualInput(string title, int maxLength)
        {
            _title = title;
            _maxLength = maxLength;
            _cursorLeft = Console.CursorLeft;
            _cursorTop = Console.CursorTop;
        }

        public int GetNumber(bool allowZero=false)
        {
            var value = 0;
            for (;;)
            {
                var input = GetInput(allowZero);
                if (!int.TryParse(input, out value))
                    continue;
                if (value == 0 && !allowZero)
                    continue;
                break;
            }
            return value;
        }

        public string GetInput(bool allowEmpty)
        {
            var input = "";
            PrintInput(input);

            for (; ; )
            {
                var key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.Escape) return string.Empty;
                if (key.Key == ConsoleKey.Enter)
                {
                    if(!allowEmpty && input.Length==0) continue;
                    break;
                }
                if (key.Key == ConsoleKey.Backspace)
                {
                    if (input.Length > 0) input = input.Substring(0, input.Length - 1);
                    PrintInput(input);
                    continue;
                }
                if (input.Length<_maxLength && char.IsLetterOrDigit(key.KeyChar))
                {
                    input += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
            }
            Console.WriteLine("");
            return input;
        }

        void PrintInput(string input)
        {
            Console.SetCursorPosition(_cursorLeft, _cursorTop);
            Console.Write("{0}: >{1}", _title, input); for (var i = 0; i < _maxLength-input.Length; i++) Console.Write(" "); Console.WriteLine("<");
            Console.SetCursorPosition(_cursorLeft + _title.Length + 3 + input.Length, _cursorTop);
        }
    }
}