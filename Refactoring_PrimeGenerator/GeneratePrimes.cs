
using System;

namespace Refactoring_PrimeGenerator
{
  public class GeneratePrimes
  {
    ///<summary>
    /// Generates an array of prime numbers.
    ///</summary>
    ///
    /// <param name="maxValue">The generation limit.</param>
    public static int[] GeneratePrimeNumbers(int maxValue)
    {
      if (maxValue >= 2) // the only valid case
      {
        // declarations
        var s = maxValue + 1;
        var f = new bool[s]; // array which holds if index/number is prime
        int i;

        //initialize array to true
        for (i = 0; i < s; i++)
        {
          f[i] = true;
        }

        //get rid of known primes

        f[0] = f[1] = false;

        //sieve
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

        // how many primes are there ??
        int count = 0;

        for (i = 0; i < s; i++)
        {
          if (f[i])
          {
            count++;
          }
        }

        int[] primes = new int[count];

        // move the primes to result

        for (i = 0,j = 0; i < s; i++)
        {
          if (f[i]) // if prime
          {
            primes[j++] = i;
          }
        }
        return primes;
      }
      else
      {
        return new int[0]; // return null array if bad input
      }

    }
  }
}
