using System;
using Microsoft.Extensions.Configuration;

namespace Section_07_03;

internal class Program
{
    private static void Main()
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        var key = "CSharpCookbook:ApiKey";
        Console.WriteLine($"{key}: {config[key]}");
    }
}
