using System;

namespace Refactoring_PrimeGenerator
{
  public class GeneratePrimesV3
  {
    private static bool[] crossedOut;
    private static int[] result;

    public static int[] GeneratePrimeNumbers(int maxValue)
    {
      if (maxValue < 2)
      {
        return new int[0];
      }

      UnCrossIntegersUpTo(maxValue);
      CrossOutMultiples();
      PutUncrossedIntegersIntoResult();
      return result;
    }

    private static void UnCrossIntegersUpTo(int maxValue)
    {
      crossedOut = new bool[maxValue + 1];
      for (int i = 2; i < crossedOut.Length; i++)
      {
        crossedOut[i] = false;
      }
    }

    private static void CrossOutMultiples()
    {
      for (int i = 2; i < Math.Sqrt(crossedOut.Length) + 1; i++)
      {
        if (NotCrossed(i)) 
        {
          CrossOutMultiplesOf(i);
        }
      }
    }

    private static void CrossOutMultiplesOf(int i)
    {
      for (int multiple = 2 * i; multiple < crossedOut.Length; multiple = multiple + i)
      {
        crossedOut[multiple] = true;
      }
    }

    private static void PutUncrossedIntegersIntoResult()
    {
      result = new int[NumberOfUncrossedIntegers()];

      for (int i = 2, j = 0; i < crossedOut.Length; i++)
      {
        if (NotCrossed(i)) 
        {
          result[j++] = i;
        }
      }
    }

    private static int NumberOfUncrossedIntegers()
    {
      int count = 0;
      for (int i = 2; i < crossedOut.Length; i++)
      {
        if (NotCrossed(i))
        {
          count++;
        }
      }
      return count;
    }

    private static bool NotCrossed(int i)
    {
      return crossedOut[i] == false;
    }

  }
}