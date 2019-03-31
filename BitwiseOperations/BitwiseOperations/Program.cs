using System;
using Gtk;
//using System.Drawing;
using System.Collections;
using System.ComponentModel;
//using System.Windows.Forms;
//using System.Data;
using System.Text;

namespace BitwiseOperations
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			MainWindow win = new MainWindow ();
			win.Show ();
			Application.Run ();
		}


	}
		
}
