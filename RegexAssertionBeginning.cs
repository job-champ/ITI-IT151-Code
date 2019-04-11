using System;
using System.Text.RegularExpressions;

class chapter8 
{
	static void Main() 
	{
		string[] words = new string[]{"heal", "heel", "noah", "techno"};
		string regExp = "^h";
		Match aMatch;

		foreach (string word in words)
			if (Regex.IsMatch(word, regExp)) 
			{
				aMatch = Regex.Match(word, regExp);
				Console.WriteLine("Matched: " + word + " at position: " + aMatch.Index);
			}
		Console.ReadKey();
	}
}
