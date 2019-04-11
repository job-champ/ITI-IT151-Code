using System;
using System.Text.RegularExpressions;

class chapter8 
{
	static void Main() 
	{
		string dates = "08/14/57 46 02/25/59 45 06/05/85 18 03/12/88 16 09/09/90 13";
		string regExp =	"(?<dates>(\\d{2}/\\d{2}/\\d{2}))\\s(?<ages>(\\d{2}))\\s";

		MatchCollection matchSet;
		matchSet = Regex.Matches(dates, regExp);
		Console.WriteLine();

		foreach (Match aMatch in matchSet) 
		{
			foreach (Capture aCapture in aMatch.Groups["dates"].Captures)
				Console.WriteLine("date capture: " + aCapture.ToString());

			foreach (Capture aCapture in aMatch.Groups["ages"].Captures)
				Console.WriteLine("age capture: " + aCapture.ToString());
		}
		Console.ReadKey();
	}
}
