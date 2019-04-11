using System;
using System.Text.RegularExpressions;

class chapter8
{
	static void Main()
	{
		Regex reg = new Regex("the");
		string str1 = "the quick brown fox jumped over the lazy dog";

		MatchCollection matchSet;
		matchSet = reg.Matches(str1);

		if (matchSet.Count > 0)
			foreach (Match aMatch in matchSet)
				Console.WriteLine("found a match at: " + aMatch.Index);

		Console.ReadKey();
	}
}
