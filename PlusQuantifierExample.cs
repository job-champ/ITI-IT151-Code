using System;
using System.Text.RegularExpressions;

class chapter8 
{
	static void Main() 
	{
		string[] words = new string[] {"bad", "boy", "baaad", "bear", "bend"};
		foreach (string word in words)
			if (Regex.IsMatch(word, "ba+"))
				Console.WriteLine(word);

		Console.ReadKey();
	}
}
