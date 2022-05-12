﻿using System.Collections.Generic;

namespace Section_07_04;

internal class Program
{
    private static void Main()
    {
        var po = GetPurchaseOrder();
        new PurchaseOrderService().View(po);
    }

    private static PurchaseOrder GetPurchaseOrder()
    {
        return new PurchaseOrder
        {
            CompanyName = "Acme, Inc.",
            Address = "123 4th St.",
            Phone = "555-835-7609",
            AdditionalInfo = new Dictionary<string, string> { { "terms", "Net 30" }, { "poc", "J. Smith" } },
            Items = new List<PurchaseItem>
            {
                new() { Description = "Widget", Price = 13.95m, Quantity = 5, SerialNumber = "123" }
            }
        };
    }
}
