using System;
using Prolog.Assembly;
using Axiom.Runtime;

// required only for AbstractTerm

namespace MyMathApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MyMath math = new MyMath();


            // Check if 2 is the minimum of 2 or 3
            if (math.min(2, 3, 2))
            {
                Console.WriteLine("Yes");
            }

            // Calculate the factorial 
            AbstractTerm a = new AbstractTerm();
            math.factorial(3, a);
            Console.WriteLine("Factorial of 3 is: " + a);

            // calculate the fifth fibonacci (should be 8)
            AbstractTerm fibValue = new AbstractTerm();
            math.fib(5, fibValue);
            Console.WriteLine("Fibonacci of 3 is: " + fibValue);
        }
    }
}
