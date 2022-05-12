using System;
using System.Security.Cryptography;
using System.Text;
using WxCollection.Extensions;

namespace Section_07_01;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("\nPassword Hash Demo\n");

        Console.Write("What is your password? ");
        var password = Console.ReadLine();

        var salt = GenerateSalt();

        var md5Hash = GenerateMD5Hash(password, salt);
        var md5HashString = Convert.ToBase64String(md5Hash);
        Console.WriteLine($"\nMD5:    {md5HashString}");

        var sha256Hash = GenerateSha256Hash(password, salt);
        var sha256HashString = Convert.ToBase64String(sha256Hash);
        Console.WriteLine($"\nSHA256: {sha256HashString}");
    }

    private static byte[] GenerateSalt()
    {
        const int SaltLength = 64;

        var salt = new byte[SaltLength];
        var rngRand = new RNGCryptoServiceProvider();

        rngRand.GetBytes(salt);
        Console.WriteLine(salt.ToHexString());

        return salt;
    }

    private static byte[] GenerateMD5Hash(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var saltedPassword =
            new byte[salt.Length + passwordBytes.Length];

        using var hash = new MD5CryptoServiceProvider();

        return hash.ComputeHash(saltedPassword);
    }

    private static byte[] GenerateSha256Hash(string password, byte[] salt)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        var saltedPassword =
            new byte[salt.Length + passwordBytes.Length];

        using var hash = new SHA256CryptoServiceProvider();

        return hash.ComputeHash(saltedPassword);
    }
}
