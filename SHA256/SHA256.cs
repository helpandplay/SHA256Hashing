using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHA256
{
  using System;
  using System.Security.Cryptography;

  namespace PenguinExpress.config
  {
    public static class SHA256
    {
      private const int minSaltLen = 12;
      private const int maxSaltLen = 36;
      private static string customSalt = string.Empty;
      private static string getSalt()
      {
        RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
        Random random = new Random();
        int randomNum = random.Next(minSaltLen, maxSaltLen);

        byte[] bytes = new byte[randomNum];
        rng.GetBytes(bytes);

        string salt = Convert.ToBase64String(bytes);
        return salt;
      }
      public static void setSalt(string salt)
      {
        if (salt.Length < minSaltLen || salt.Length > maxSaltLen)
        {
          throw new Exception("salt의 길이를 확인하세요.");
        }
        SHA256.customSalt = salt;
      }
      public static string Hashing(string pwd)
      {
        string salt = string.Empty;
        if (customSalt == string.Empty) salt = getSalt();
        else customSalt = salt;


      }
      public static bool isEqualPwd(string input, string dbPwd, string salt)
      {
        Hashing();
      }

    }
  }

}
