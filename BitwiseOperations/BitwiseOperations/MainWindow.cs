using System;
using Gtk;
using System.Text;

public partial class MainWindow: Gtk.Window
{
	public MainWindow () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
		label5.Text = "";
		label6.Text = "";
		label7.Text = "";
		button3.Sensitive = false;
		button4.Sensitive = false;
		button5.Sensitive = false;
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}

	protected void btnAndPressed (object o, ButtonPressEventArgs args)
	{
		throw new NotImplementedException ();
	}

	protected void OnButton2Pressed (object sender, EventArgs e)
	{
		Application.Quit ();
	}

	protected void OnButton3Pressed (object sender, EventArgs e)
	{
		int val1, val2;
		val1 = Int32.Parse(entry4.Text);
		val2 = Int32.Parse(entry5.Text);
		label5.Text = ConvertBits(val1).ToString();
		label6.Text = ConvertBits(val2).ToString();
		label7.Text = ConvertBits(val1 & val2).ToString();
	}

	private StringBuilder ConvertBits (int val)
	{
		int dispMask = 1 << 31;
		StringBuilder bitBuffer = new StringBuilder (35);
		for (int i = 1; i <= 32; i++) 
		{
			if ((val & dispMask) == 0)
				bitBuffer.Append ("0");
			else
				bitBuffer.Append ("1");
			val <<= 1;
			if ((i % 8) == 0)
				bitBuffer.Append (" ");
		}
		return bitBuffer;
	}
		
	protected void OnButton1Pressed (object sender, EventArgs e)
	{
		label5.Text = "";
		label6.Text = "";
		label7.Text = "";
		entry4.Text = "";
		entry5.Text = "";
		entry4.IsFocus = true;
	}

	protected void OnButton4Pressed (object sender, EventArgs e)
	{
		int val1, val2;
		val1 = Int32.Parse(entry4.Text);
		val2 = Int32.Parse(entry5.Text);
		label5.Text = ConvertBits(val1).ToString();
		label6.Text = ConvertBits(val2).ToString();
		label7.Text = ConvertBits(val1 | val2).ToString();
	}

	protected void OnButton5Pressed (object sender, EventArgs e)
	{
		int val1, val2;
		val1 = Int32.Parse(entry4.Text);
		val2 = Int32.Parse(entry5.Text);
		label5.Text = ConvertBits(val1).ToString();
		label6.Text = ConvertBits(val2).ToString();
		label7.Text = ConvertBits(val1 ^ val2).ToString();
	}
		

	protected void OnEntry4Changed (object sender, EventArgs e)
	{
		int output = 0;

		if (entry4.Text.Length > 0 && int.TryParse (entry4.Text, out output) == true && entry5.Text.Length > 0 && int.TryParse (entry5.Text, out output) == true) 
		{
			button3.Sensitive = true; 
			button4.Sensitive = true;
			button5.Sensitive = true;
		} 
		else 
		{
			button3.Sensitive = false;
			button4.Sensitive = false;
			button5.Sensitive = false;
		}
	}

	protected void OnEntry5Changed (object sender, EventArgs e)
	{
		int output = 0;

		if (entry4.Text.Length > 0 && int.TryParse (entry4.Text, out output) == true && entry5.Text.Length > 0 && int.TryParse (entry5.Text, out output) == true) 
		{
			button3.Sensitive = true; 
			button4.Sensitive = true;
			button5.Sensitive = true;
		} 
		else 
		{
			button3.Sensitive = false;
			button4.Sensitive = false;
			button5.Sensitive = false;
		}
	}
}
