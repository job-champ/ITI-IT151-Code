using System;
using System.Collections;

public class CSet
{
	public Hashtable data;

	public CSet ()
	{
		data = new Hashtable ();
	}

	public void Add (Object item)
	{
		if (!(data.ContainsValue (item)))
			data.Add (Hash (item), item);
	}

	public string Hash (Object item)
	{
		char[] chars;
		string s = item.ToString ();
		chars = s.ToCharArray ();
		int hashValue = 0;

		for (int i = 0; i <= chars.GetUpperBound (0); i++)
			hashValue += (int)chars [i];

		return hashValue.ToString ();
	}

	public void Remove (Object item)
	{
		data.Remove (Hash (item));
	}

	public int Size ()
	{
		return data.Count;
	}

	public CSet Union (CSet aSet)
	{
		CSet tempSet = new CSet ();

		foreach (Object hashObject in data.Keys)
			tempSet.Add (this.data [hashObject]);

		foreach (Object hashObject in aSet.data.Keys)
			if (!(this.data.ContainsKey (hashObject)))
				tempSet.Add (aSet.data [hashObject]);

		return tempSet;
	}

	public CSet Intersection (CSet aSet)
	{
		CSet tempSet = new CSet ();

		foreach (Object hashObject in data.Keys)
			if (aSet.data.Contains (hashObject))
				tempSet.Add (data [hashObject]);

		return tempSet;
	}

	public bool isSubset (CSet aSet)
	{
		if (this.Size () > aSet.Size ())
			return false;
		else
			foreach (Object key in this.data.Keys)
				if (!(aSet.data.Contains (key)))
					return false;

		return true;
	}

	public CSet Difference (CSet aSet)
	{
		CSet tempSet = new CSet ();

		foreach (Object hashObject in data.Keys)
			if (!(aSet.data.Contains (hashObject)))
				tempSet.Add (data [hashObject]);

		return tempSet;
	}

	public override string ToString ()
	{
		string s = "";

		foreach (Object key in data.Keys)
			s += data [key] + " ";

		return s;
	}
}

public class chapter13
{
	static void Main ()
	{
		CSet setA = new CSet ();
		CSet setB = new CSet ();
		setA.Add ("milk");
		setA.Add ("eggs");
		setA.Add ("bacon");
		setA.Add ("cereal");
		setB.Add ("bacon");
		setB.Add ("eggs");
		setB.Add ("bread");
		CSet setC = new CSet ();

		setC = setA.Union (setB);
		Console.WriteLine ();
		Console.WriteLine ("A: " + setA.ToString ());
		Console.WriteLine ("B: " + setB.ToString ());
		Console.WriteLine ("A union B: " + setC.ToString ());

		setC = setA.Intersection (setB);
		Console.WriteLine ("A intersect B: " +	setC.ToString ());

		setC = setA.Difference (setB);
		Console.WriteLine ("A diff B: " + setC.ToString ());
		setC = setB.Difference (setA);
		Console.WriteLine ("B diff A: " + setC.ToString ());

		if (setB.isSubset (setA))
			Console.WriteLine ("b is a subset of a");
		else
			Console.WriteLine ("b is not a subset of a");

		Console.ReadKey();
	}
}
