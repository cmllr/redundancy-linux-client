using System;
using Gtk;
using Gdk;

namespace clientRedundancy
{
	public class UserInterface
	{
		public StatusIcon trayIcon;
		public Settings winSettings;

		public UserInterface ()
		{
			InitializeTrayIcon ();
			InitializeWinSettings ();
		}

		public void InitializeTrayIcon()
		{
			trayIcon = new StatusIcon ();
			trayIcon.Tooltip = "Redundancy for Linux";
			trayIcon.Pixbuf = Pixbuf.LoadFromResource("clientRedundancy.Resources.redundancy.ico");
			trayIcon.Visible = true;
			trayIcon.PopupMenu += OnTrayIconPopup;
		}

		public void OnTrayIconPopup (object o, EventArgs args)
		{
			Menu popupMenu = new Menu ();

			ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
			ImageMenuItem menuItemSettings = new ImageMenuItem ("Settings");

			menuItemQuit.Image = new Gtk.Image (Stock.Quit, IconSize.Menu);
			menuItemSettings.Image = new Gtk.Image (Stock.Preferences, IconSize.Menu);

			popupMenu.Add (menuItemSettings);
			popupMenu.Add (menuItemQuit);

			menuItemSettings.Activated += delegate(object sender, EventArgs e) { winSettings.Show(); };
			menuItemQuit.Activated += delegate { Application.Quit (); };

			popupMenu.ShowAll ();
			popupMenu.Popup ();
		}

		public void InitializeWinSettings()
		{
			winSettings = new Settings();
			winSettings.Visible = false;
		}
	}
}

