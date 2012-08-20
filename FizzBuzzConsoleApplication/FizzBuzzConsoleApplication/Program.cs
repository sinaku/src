using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FizzBuzzConsoleApplication
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                string buf = string.Empty;

                if (i % 3 == 0)
                    buf += @"Fizz";
                if (i % 5 == 0)
                    buf += @"Buzz";

                Console.WriteLine(buf == string.Empty ? i.ToString() : buf);
            }

            Console.ReadLine();
        }
    }
}