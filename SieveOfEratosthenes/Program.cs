using System;
using System.Collections.Generic;

namespace SieveOfEratosthenes
{
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;

            do
            {
                Console.Write("Maximum number in checked range: ");
                if (int.TryParse(Console.ReadLine(), out max) && max > 1)
                {
                    break;
                }
                Console.WriteLine("Maximum number must be a number and greater than 1");
            } while (true);

            bool[] A = new bool[max + 1];

            Array.Fill(A, true);

            A[0] = false;
            A[1] = false;

            for (int i = 2; i < Math.Sqrt(max); i++)
            {
                if (A[i])
                {
                    for (int j = (int)Math.Pow(i, 2); j <= max; j += i)
                    {
                        A[j] = false;
                    }
                }
            }

            PrintPrimeNumbersWithoutHelperList(max, A);
            PrintPrimeNumbers(max, A);
        }

        // Faster printing, more memory used
        static void PrintPrimeNumbers(int max, bool[] sieve)
        {
            var primeNumbers = new List<int>();

            for (int i = 0; i <= max; i++)
            {
                if (sieve[i])
                    primeNumbers.Add(i);
            }

            Console.WriteLine(string.Join(", ", primeNumbers));
        }

        // Slower printing, less memory used
        static void PrintPrimeNumbersWithoutHelperList(int max, bool[] sieve)
        {
            for (int i = 0; i <= max; i++)
            {
                if (sieve[i])
                    Console.Write("{0} ", i);
            }
        }
    }
}
