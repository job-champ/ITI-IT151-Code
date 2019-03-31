using System;

public class sieve
{
	public static void GenPrimes(int[] arr) 
	{
		for(int outer = 2; outer < arr.Length; outer++)
			for(int inner = outer+1; inner < arr.Length; inner++)
				if (arr[inner] == 1)
				if ((inner % outer) == 0)
					arr[inner] = 0;
	}

	public static void ShowPrimes(int[] arr) 
	{
		for(int i = 2; i < arr.Length; i++)
			if (arr[i] == 1)
				Console.Write(i + " ");
	}

	public static void Main() 
	{
		int size = 100;
		int[] primes = new int[size - 1];

		for(int i = 0; i < size-1; i++)
			primes[i] = 1;

		GenPrimes(primes);
		ShowPrimes(primes);
	}
}
