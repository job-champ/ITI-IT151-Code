using System;
using System.Text.RegularExpressions;

class chapter8 
{
	static void Main() 
	{
		string words = "08/14/57 46 02/25/59 45 06/05/85 18 " +	"03/12/88 16 09/09/90 13";
		string regExp1 = "(?<dates>(\\d{2}/\\d{2}/\\d{2}))\\s";
		MatchCollection matchSet = Regex.Matches(words,	regExp1);

		foreach (Match aMatch in matchSet)
			Console.WriteLine("Date: {0}", aMatch.Groups["dates"]);

		Console.ReadKey();
	}
}
