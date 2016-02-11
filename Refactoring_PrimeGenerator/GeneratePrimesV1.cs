using System;

namespace Refactoring_PrimeGenerator
{
  public class GeneratePrimesV1
  {
    static bool[] f;
    private static int s;
    private static int[] primes;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
      if (maxValue < 2)
      {
        return new int[0];
      }

      InitializeSieve(maxValue);
      Sieve();
      LoadPrimes();
      return primes;
    }

    private static void InitializeSieve(int maxValue)
    {
      s = maxValue + 1;
      f = new bool[s]; // array which holds if index/number is prime
      int i;

      //initialize array to true
      for (i = 0; i < s; i++)
      {
        f[i] = true;
      }

      //get rid of known primes

      f[0] = f[1] = false;
    }

    private static void Sieve()
    {
      int i;
      int j;
      for (i = 2; i < Math.Sqrt(s) + 1; i++)
      {
        if (f[i]) // if i is uncrossed cross its multiples
        {
          for (j = 2 * i; j < s; j = j + i)
          {
            f[j] = false;
          }
        }
      }
    }

    private static void LoadPrimes()
    {
      int i;
      int j;
      int count = 0;

      for (i = 0; i < s; i++)
      {
        if (f[i])
        {
          count++;
        }
      }

      primes = new int[count];

      // move the primes to result

      for (i = 0,j = 0; i < s; i++)
      {
        if (f[i]) // if prime
        {
          primes[j++] = i;
        }
      }
    }

  }
}