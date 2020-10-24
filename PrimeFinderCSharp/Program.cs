using System;
using System.Collections.Generic;

namespace PrimeFinderCSharp
{
    /// <summary>
    /// A program to find all prime integers between 1 and N.
    /// </summary>
    /// <remarks>
    /// The basic algorithm works like this:
    /// for each number (num) from 2 to n:
    ///     find the modulo of num and all the prime numbers less than the square root of n
    ///     if none of the prime numbers modulo with num to equal zero, than num is prime
    ///     else num is not prime
    /// this is possible because composite numbers can be seen as prime numbers multiplied together
    /// therefore we only need to divide by prime numbers to check for primality, because all non-prime 
    /// numbers can be factorized into prime numbers.
    /// this algorithm is effectively more efficient repeated division.
    /// </remarks>
    class Program
    {
        static void Main()
        {
            // Read input from the user.
            Console.WriteLine("This is a program to find all primes from 1 to N.");
            Console.WriteLine("Please enter a number: ");

            var validInput = false;
            long n = 0;
            while(!validInput)
            {
                var input = Console.ReadLine();
                try
                {
                    n = long.Parse(input);

                    if (n < 1)
                    {
                        Console.WriteLine($"Invalid integer: \"{input}\"");
                    }
                    else
                    {
                        validInput = true;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Invalid input: \"{input}\"");
                }
            }

            // Find all the prime numbers.
            var primeList = new List<long>();
            for (long i = 2; i <= n; i++)
            {
                // The square root is used to reduce the amount of division needed to do;
                // factors repeat past the square root.
                // Ex: sqrt(20) = 4.472 = 5
                // 20 = 2 * 10
                //    = 4 * 5
                //    = 5 * 4
                //    = 10 * 2
                var sq = Math.Ceiling(Math.Sqrt(i));
                var isPrime = true;

                for (int j = 0; j < primeList.Count && isPrime && primeList[j] <= sq; j++)
                {
                    if (i % primeList[j] == 0)
                    {
                        isPrime = false;
                    }
                }

                if (isPrime)
                {
                    primeList.Add(i);
                }
            }

            // Print out all the found prime numbers.
            Console.WriteLine($"Prime numbers from 1 to {n}:");
            foreach (var prime in primeList)
            {
                Console.WriteLine(prime);
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }
    }
}
