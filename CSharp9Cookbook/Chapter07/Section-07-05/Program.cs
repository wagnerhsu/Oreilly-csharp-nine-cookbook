using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Section_07_05;

internal class Program
{
    private static void Main()
    {
        var poJson =
            new PurchaseOrderService()
                .Get(123);

        var jsonOptions = new JsonSerializerOptions
        {
            AllowTrailingCommas = true,
            Converters = { new PurchaseOrderStatusConverter() },
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = new SnakeCaseNamingPolicy(),
            WriteIndented = true
        };

        var po =
            JsonSerializer
                .Deserialize<PurchaseOrder>(poJson, jsonOptions);

        Console.WriteLine($"{po.CompanyName}");
        Console.WriteLine($"{po.AdditionalInfo["terms"]}");
        Console.WriteLine($"{po.Items[0].Description}");

        var poJson2 = JsonSerializer.Serialize(po, jsonOptions);

        Console.WriteLine(poJson2);
        Console.WriteLine("Default serialize:");
        Console.WriteLine(JsonSerializer.Serialize(po));
    }
}
