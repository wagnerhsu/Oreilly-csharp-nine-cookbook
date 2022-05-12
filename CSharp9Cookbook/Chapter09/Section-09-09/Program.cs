using System;

namespace Section_09_09
{
    internal class Program
    {
        private static void Main()
        {
            AddressService addressSvc = new();

            foreach (var addresses in
                     addressSvc.GetAddresses(3))
            {
                foreach (var address in addresses) Console.WriteLine(address);

                Console.WriteLine("\nNew Page\n");
            }
        }
    }
}