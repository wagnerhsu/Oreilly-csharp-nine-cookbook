using System;

namespace Section_09_04
{
    internal record Address(
        string Street,
        string City,
        string State,
        string Zip);

    internal class Program
    {
        private static void Main(string[] args)
        {
            var addressClassic = new Address(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890");

            // or

            Address addressCtorInit = new(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890");

            // not allowed
            //addressCtorInit.Street = "333 2nd St.";

            Console.WriteLine(
                $"Value Equal:     " +
                $"{addressClassic == addressCtorInit}");
            Console.WriteLine(
                $"Reference Equal: " +
                $"{ReferenceEquals(addressClassic, addressCtorInit)}");

            Console.WriteLine(
                $"{nameof(addressClassic)}: {addressClassic}");
            Console.WriteLine(
                $"{nameof(Address)}:        {addressCtorInit}");
        }
    }
}