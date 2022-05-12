using System;

namespace Section_09_07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Communications comm = new();
            var mailAddr = comm.GetAddress("Person A");
            Console.WriteLine(mailAddr);

            Shipping ship = new();
            var shipAddr = ship.GetAddress("Person B");
            Console.WriteLine(shipAddr);
        }
    }
}