using System;
using Gtk;

public partial class Settings: Gtk.Window
{
	public Settings () : base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}

	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		HideOnDelete ();
		a.RetVal = true;
	}
}
