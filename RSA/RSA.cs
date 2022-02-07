using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace Encrypted
{
  public class RSA
  {
    private bool Ready_check;
    private long local_D;

    public long p;
    public long q;
    public long n;
    public long e;

    public RSA()
    {
      Initialize();
    }

    public void Initialize()
    {
      p = PrimeNumberGenerator.Generate();
      q = PrimeNumberGenerator.Generate();

      n = p * q;

      var f = (p - 1) * (q - 1);

      e = GetPublicPartKey(f);
      local_D = GetPrivatePartKey(f, e);

      Ready_check = true;
    }

    #region Проверка готовности ключей и шифрование
    public string[] Encrypt(string text, long publicE, long publicN)
    {
      if (!Ready_check)
        throw new ArgumentException("Method Initialize not called");

      return Encode(text, publicE, publicN);
    }
    #endregion

    #region Проверка наличия установленных ключей и расшифровка
    public string Decrypt(string[] encrypted_msg)
    {
      if (!Ready_check)
        throw new ArgumentException("Method Initialize not called");

      return Decode(encrypted_msg, local_D, n);
    }
    #endregion

    #region Шифрование методом RSA
    private string[] Encode(string msg, long e, long n)
    {
      var encrypted_msg = new List<string>();

      BigInteger num;

      foreach (var ch in msg)
      {
        int index = ch;

        num = BigInteger.ModPow(index, e, n);

        encrypted_msg.Add(num.ToString());
      }

      return encrypted_msg.ToArray();
    }
    #endregion

    #region Дешифрирование методом RSA
    private string Decode(string[] encrypted_msg, long d, long n)
    {
      var strBuilder = new StringBuilder();

      BigInteger num;

      foreach (var item in encrypted_msg)
      {
        var val = new BigInteger(Convert.ToInt64(item));
        num = BigInteger.ModPow(val, d, n);

        strBuilder.Append((char)num);
      }

      return strBuilder.ToString();
    }
    #endregion

    #region Получить свой приватный ключ
    private long GetPrivatePartKey(long f, long e)
    {
      long d = e + 1;

      while (true)
      {
        if ((d * e) % f == 1)
          break;
        d++;
      }

      return d;
    }
    #endregion

    #region Получить свой публичный ключ для обмена
    private long GetPublicPartKey(long f)
    {
      long e = f - 1;

      while (true)
      {
        if (PrimeNumberGenerator.IsPrime(e) &&
            e < f &&
            BigInteger.GreatestCommonDivisor(new BigInteger(e), new BigInteger(f)) == BigInteger.One)
          break;
        e--;
      }

      return e;
    }
    #endregion
  }
}
