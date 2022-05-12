using System;
using System.Security.Cryptography;

namespace Section_07_02;

internal class Program
{
    private static void Main()
    {
        var crypto = new Crypto();

        Console.Write("Please enter text to encrypt: ");
        var userPlainText = Console.ReadLine();

        var key = GenerateKey();

        var cypherBytes = crypto.Encrypt(userPlainText, key);

        var cypherText = Convert.ToBase64String(cypherBytes);

        Console.WriteLine($"Cypher Text: {cypherText}");

        var decryptedPlainText = crypto.Decrypt(cypherBytes, key);

        Console.WriteLine($"Plain Text: {decryptedPlainText}");
    }

    private static byte[] GenerateKey()
    {
        const int KeyLength = 32;

        var key = new byte[KeyLength];
        var rngRand = new RNGCryptoServiceProvider();

        rngRand.GetBytes(key);

        return key;
    }
}
