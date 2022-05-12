using System;

namespace Section_09_06
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            MailingAddress mailAddress = new(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890",
                "me@example.com",
                true);

            ShippingAddress shipAddress = new(
                "567 8th Ave.",
                "Some Place",
                "YY",
                "12345-7890",
                "Ring Doorbell");

            Console.WriteLine($"Mail: {mailAddress}");
            Console.WriteLine($"Ship: {shipAddress}");

            Console.WriteLine(
                $"Derived types equal: " +
                $"{mailAddress == shipAddress}");

            AddressBase mailBase = mailAddress;
            AddressBase shipBase = shipAddress;
            Console.WriteLine(
                $"Base types equal: " +
                $"{mailBase == shipBase}");
        }
    }
}