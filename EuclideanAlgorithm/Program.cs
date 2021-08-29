using System;
using System.Diagnostics;

namespace Euclidean_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            var sw = new Stopwatch();
            int a, b;
            do
            {
                Console.Write("Specify two numbers: ");

                var line = Console.ReadLine().Split(" ")[0..2];

                if (
                    int.TryParse(line[0], out a)
                    && int.TryParse(line[1], out b)
                   )
                    break;

                Console.WriteLine("Both values must be numbers");

            } while (true);

            // Modulo method
            sw.Start();

            Console.WriteLine("Greatest Common Divisor of {0} and {1} is {2} (Modulo method)", a, b, GreatestCommonDivisorWithModulo(a,b));

            sw.Stop();
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            // Comparison method
            sw.Restart();

            Console.WriteLine("Greatest Common Divisor of {0} and {1} is {2} (Comparison method)", a, b, GreatestCommonDivisorWithValueComparison(a,b));

            sw.Stop();
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);

            // Recurention method
            sw.Restart();

            Console.WriteLine("Greatest Common Divisor of {0} and {1} is {2} (Recurention method)", a, b, GreatestCommonDivisorRecursive(a,b));

            sw.Stop();
            Console.WriteLine("Elapsed: {0}", sw.Elapsed);
        }
        static int GreatestCommonDivisorWithModulo(int number1, int number2)
        {
            int temp;
            while (number2 != 0)
            {
                temp = number2;
                number2 = number1 % number2;
                number1 = temp;
            }
            return number1;
        }
        static int GreatestCommonDivisorWithValueComparison(int number1, int number2)
        {
            while (number1 != number2)
            {
                if (number1 > number2)
                    number1 = number1 - number2;
                else
                    number2 = number2 - number1;
            }
            return number1;
        }
        static int GreatestCommonDivisorRecursive(int number1, int number2)
        {
            if (number2 == 0)
                return number1;
            else
                return GreatestCommonDivisorRecursive(number2, number1 % number2);
        }
    }
}
