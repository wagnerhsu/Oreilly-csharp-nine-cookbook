using System;
using System.Linq;

namespace Section_07_09;

internal class Program
{
    private static void Main()
    {
        const string OriginalUrl =
            "https://myco.com/po/search?company=computers+";
        Console.WriteLine($"Original:    '{OriginalUrl}'");

        var escapedUri = Uri.EscapeUriString(OriginalUrl);
        Console.WriteLine($"Escape URI:  '{escapedUri}'");

        var escapedData = Uri.EscapeDataString(OriginalUrl);
        Console.WriteLine($"Escape Data: '{escapedData}'");

        var escapedUrl = EscapeUrlParams(OriginalUrl);
        Console.WriteLine($"Escaped URL: '{escapedUrl}'");
    }

    private static string EscapeUrlParams(string originalUrl)
    {
        const int Base = 0;
        const int Parms = 1;
        const int Key = 0;
        const int Val = 1;
        var parts = originalUrl.Split('?');
        var pairs = parts[Parms].Split('&');

        var escapedParms =
            string.Join('&',
                (from pair in pairs
                    let keyVal = pair.Split('=')
                    let encodedVal = Url.PercentEncode(keyVal[Val])
                    select $"{keyVal[Key]}={encodedVal}")
                .ToList());

        return $"{parts[Base]}?{escapedParms}";
    }
}
