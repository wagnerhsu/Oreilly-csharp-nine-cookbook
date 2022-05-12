using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Section_07_05;

public class SnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        var targetChars = new List<char>();
        var sourceChars = name.ToCharArray();

        var first = sourceChars[0];
        if (char.IsUpper(first))
        {
            targetChars.Add(char.ToLower(first));
        }
        else
        {
            targetChars.Add(first);
        }

        for (var i = 1; i < sourceChars.Length; i++)
        {
            var ch = sourceChars[i];

            if (char.IsUpper(ch))
            {
                targetChars.Add('_');
                targetChars.Add(char.ToLower(ch));
            }
            else
            {
                targetChars.Add(ch);
            }
        }

        return new string(targetChars.ToArray());
    }
}
