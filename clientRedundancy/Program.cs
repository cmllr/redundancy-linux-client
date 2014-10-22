using System;
using Gtk;

namespace clientRedundancy
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			Application.Init ();
			UserInterface ui = new UserInterface ();
			Application.Run ();
		}
	}
}
