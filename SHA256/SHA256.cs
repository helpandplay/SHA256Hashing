using System;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Library {

  public static class SHA256Hash
  {
    private const int minSaltLen = 12;
    private const int maxSaltLen = 36;
    private static byte[] Salting(string src, string salt)
    {
      byte[] convertSrc = Encoding.ASCII.GetBytes(src);
      byte[] msg = Encoding.ASCII.GetBytes(salt);
      byte[] combined = msg.Concat(convertSrc).ToArray();

      return combined;
    }
    private static string ByteToString(byte[] data)
    {
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte b in data)
        stringBuilder.AppendFormat("{0:x2}", b); //16진수로 변환

      return stringBuilder.ToString();
    }
    public static string GetSalt()
    {
      RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
      Random random = new Random();
      int randomNum = random.Next(minSaltLen, maxSaltLen);

      byte[] bytes = new byte[randomNum];
      rng.GetNonZeroBytes(bytes);

      return ByteToString(bytes);
    }
    public static string HashingSHA256(string src, string salt)
    {
      byte[] combined = Salting(src, salt);
      byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(combined);

      return ByteToString(hash);
    }
    public static bool Compare(string src, string salt, string target)
    {
      return HashingSHA256(src, salt) == target;
    }
  }
}