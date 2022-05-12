using System;
using System.Linq;
using System.Xml.Linq;

namespace Section_07_07;

internal class Program
{
    private static void Main(string[] args)
    {
        XNamespace or = "https://www.oreilly.com";

        var address = or + nameof(PurchaseOrder.Address);
        var company = or + nameof(PurchaseOrder.CompanyName);
        var phone = or + nameof(PurchaseOrder.Phone);
        var status = or + nameof(PurchaseOrder.Status);
        var info = or + nameof(PurchaseOrder.AdditionalInfo);
        var poItems = or + nameof(PurchaseOrder.Items);
        var purchaseItem = or + nameof(PurchaseItem);
        var description = or + nameof(PurchaseItem.Description);
        var price = or + nameof(PurchaseItem.Price);
        var quantity = or + nameof(PurchaseItem.Quantity);
        XName serialNum = nameof(PurchaseItem.SerialNumber);

        var poXml = GetXml();

        var poElmt = XElement.Parse(poXml);

        PurchaseOrder po =
            new()
            {
                Address = (string)poElmt.Element(address),
                CompanyName = (string)poElmt.Element(company),
                Phone = (string)poElmt.Element(phone),
                Status =
                    Enum.TryParse(
                        (string)poElmt.Element(nameof(po.Status)),
                        out PurchaseOrderStatus poStatus)
                        ? poStatus
                        : PurchaseOrderStatus.Received,
                AdditionalInfo =
                    (from addInfo in poElmt.Element(info).Descendants()
                        select addInfo)
                    .ToDictionary(
                        key => key.Name.LocalName,
                        val => val.Value),
                Items =
                    (from item in poElmt
                            .Element(poItems)
                            .Descendants(purchaseItem)
                        select new PurchaseItem
                        {
                            Description = (string)item.Element(description),
                            Price =
                                decimal.TryParse(
                                    (string)item.Element(price),
                                    out var itemPrice)
                                    ? itemPrice
                                    : 0m,
                            Quantity =
                                float.TryParse(
                                    (string)item.Element(quantity),
                                    out var qty)
                                    ? qty
                                    : 0f,
                            SerialNumber = (string)item.Attribute(serialNum)
                        })
                    .ToList()
            };

        Console.WriteLine($"{po.CompanyName}");
        Console.WriteLine($"{po.AdditionalInfo["Terms"]}");
        Console.WriteLine($"{po.Items[0].Description}");
        Console.WriteLine($"{po.Items[0].SerialNumber}");
    }

    private static string GetXml()
    {
        return @"
<PurchaseOrder xmlns=""https://www.oreilly.com"">
  <Address>123 4th St.</Address>
  <CompanyName>Acme, Inc.</CompanyName>
  <Phone>555-835-7609</Phone>
  <Status>Received</Status>
  <AdditionalInfo>
    <Terms>Net 30</Terms>
    <POC>J. Smith</POC>
  </AdditionalInfo>
  <Items>
    <PurchaseItem SerialNumber=""123"">
      <Description>Widget</Description>
      <Price>13.95</Price>
      <Quantity>5</Quantity>
    </PurchaseItem>
  </Items>
</PurchaseOrder>";
    }
}
