using System;

Console.WriteLine("Address Info:\n");

Console.Write("Street: ");
var street = Console.ReadLine();

Console.Write("City: ");
var city = Console.ReadLine();

Console.Write("State: ");
var state = Console.ReadLine();

Console.Write("Zip: ");
var zip = Console.ReadLine();

Console.WriteLine($@"
    Your address is:

    {street}
    {city}, {state} {zip}");