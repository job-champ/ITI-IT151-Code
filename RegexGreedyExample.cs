using System;
using System.Text.RegularExpressions;

class chapter8 {
	static void Main() 
	{
		string[] words = new string[]{"Part", "of", "this", "<b>string</b>", "is", "bold"};
		string regExp = "<.*>";
		MatchCollection aMatch;

		foreach (string word in words) 
		{
			if (Regex.IsMatch(word, regExp)) 
			{
				aMatch = Regex.Matches(word, regExp);

				for(int i = 0; i < aMatch.Count; i++)
					Console.WriteLine(aMatch[i].Value);
			}
		}
		Console.ReadKey();
	}
}
