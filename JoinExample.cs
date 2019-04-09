using System;
class Chapter7 
{
	static void Main() 
	{
		string data = "Mike,McMillan,3000 W. Scenic,North Little Rock,AR,72118";
		string[] sdata;
		char[] delimiter = new char[] {','};
		sdata = data.Split(delimiter, data.Length);
		foreach (string word in sdata)
			Console.Write(word + " ");

		string joined;
		joined = String.Join(",", sdata);
		Console.Write(joined);
	}
}
