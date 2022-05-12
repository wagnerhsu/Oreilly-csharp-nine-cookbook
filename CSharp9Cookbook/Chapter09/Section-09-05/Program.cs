using System;

namespace Section_09_05
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
            Address addressPre = new(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890");

            var addressPost =
                addressPre with
                {
                    Street = "569 8th Ave."
                };

            Console.WriteLine($"Pre:  {addressPre}");
            Console.WriteLine($"Post: {addressPost}");

            Console.WriteLine(
                $"Value Equal: " +
                $"{addressPre == addressPost}");
        }
    }
}