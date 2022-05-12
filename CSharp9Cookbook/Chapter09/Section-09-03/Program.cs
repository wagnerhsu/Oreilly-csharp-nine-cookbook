using System;

namespace Section_09_03
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Address addressObjectInit = new()
            {
                Street = "123 4th St.",
                City = "My City",
                State = "ZZ",
                Zip = "55555-3333"
            };

            // not allowed
            //addressObjectInit.City = "A Locality";

            // target typed with ctor init
            Address addressCtorInit = new(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890");

            // not allowed
            //addressCtorInit.Zip = "98765";
        }
    }
}