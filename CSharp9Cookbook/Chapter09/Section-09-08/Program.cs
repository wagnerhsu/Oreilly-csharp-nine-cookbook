using System;
using System.Collections.Generic;

namespace Section_09_08
{
    internal class Program
    {
        private static void Main()
        {
            var addresses = GetAddresses();

            foreach (var address in addresses)
            {
                foreach (var line in address)
                    Console.WriteLine(line);

                Console.WriteLine();
            }
        }

        private static IEnumerable<Address> GetAddresses()
        {
            return new List<Address>
            {
                new(
                    "567 8th Ave.",
                    "Some Place",
                    "YY",
                    "12345-7890"),
                new(
                    "569 8th Ave.",
                    "Some Place",
                    "YY",
                    "12345-7890")
            };
        }
    }
}