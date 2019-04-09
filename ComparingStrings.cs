using System;
using System.Text;


class chapt7
{
	static void Main() 
	{
		string s1 = "foobar";
		string s2 = "foobar";

		int compVal = String.Compare(s1, s2);
		switch(compVal) 
		{
			case 0 : Console.WriteLine(s1 + " " + s2 + " are equal");
			break;
			case 1 : Console.WriteLine(s1 + " is less than " + s2);
			break;
			case 2 : Console.WriteLine(s1 + " is greater than" + s2);
			break;
			default : Console.WriteLine("Can't compare");
			break;
		}
	}
}
