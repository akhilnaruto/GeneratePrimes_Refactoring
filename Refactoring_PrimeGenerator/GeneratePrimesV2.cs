using System;

namespace Refactoring_PrimeGenerator
{
  public class GeneratePrimesV2
  {
    static bool[] f;
    private static int[] primes;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
      if (maxValue < 2)
      {
        return new int[0];
      }

      InitializeArrayOfIntegers(maxValue);
      CrossOutMultiples();
      PutUncrossedIntegersIntoResult();
      return primes;
    }

    private static void InitializeArrayOfIntegers(int maxValue)
    {
      f = new bool[maxValue + 1]; // array which holds if index/number is prime
      f[0] = f[1] = false;  //neither primes nor multiples
    
      //initialize array to true
      for (int i = 2; i < f.Length; i++)
      {
        f[i] = true;
      }

    

    }

    private static void CrossOutMultiples()
    {
      int i;
      int j;
      for (i = 2; i < Math.Sqrt(f.Length) + 1; i++)
      {
        if (f[i]) // if i is uncrossed cross its multiples
        {
          for (j = 2 * i; j < f.Length; j = j + i)
          {
            f[j] = false;
          }
        }
      }
    }

    private static void PutUncrossedIntegersIntoResult()
    {
      int i;
      int j;
      int count = 0;

      for (i = 0; i < f.Length; i++)
      {
        if (f[i])
        {
          count++;
        }
      }

      primes = new int[count];

      // move the primes to result

      for (i = 0, j = 0; i < f.Length; i++)
      {
        if (f[i]) // if prime
        {
          primes[j++] = i;
        }
      }
    }
  }
}