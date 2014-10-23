using System;
using Gtk;
using Gdk;

namespace clientRedundancy
{
	public class UserInterface
	{
		public StatusIcon trayIcon;
		public Settings winSettings;

		/// <summary>
		/// Initializes a new instance of the <see cref="clientRedundancy.UserInterface"/> class.
		/// </summary>
		public UserInterface ()
		{
			InitializeTrayIcon ();
			InitializeWinSettings ();
		}

		/// <summary>
		/// Initializes the tray icon.
		/// </summary>
		public void InitializeTrayIcon()
		{
			// trayIcon attributes
			trayIcon = new StatusIcon ();
			trayIcon.Tooltip = "Redundancy for Linux";
			trayIcon.Pixbuf = Pixbuf.LoadFromResource("clientRedundancy.Resources.redundancy.ico");
			trayIcon.Visible = true;

			// trayIcon events
			trayIcon.PopupMenu += OnTrayIconPopup;
		}

		/// <summary>
		/// Initializes the settings window.
		/// </summary>
		public void InitializeWinSettings()
		{
			winSettings = new Settings();
			winSettings.Visible = false;
		}

		#region Events

		/// <summary>
		/// Event handler for the trayIcon context menu.
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="args">Arguments.</param>
		public void OnTrayIconPopup (object sender, EventArgs args)
		{
			Menu popupMenu = new Menu ();

			// Menu items
			ImageMenuItem menuItemQuit = new ImageMenuItem ("Quit");
			ImageMenuItem menuItemSettings = new ImageMenuItem ("Settings");

			// Icons
			menuItemQuit.Image = new Gtk.Image (Stock.Quit, IconSize.Menu);
			menuItemSettings.Image = new Gtk.Image (Stock.Preferences, IconSize.Menu);

			popupMenu.Add (menuItemSettings);
			popupMenu.Add (menuItemQuit);

			// Events
			menuItemSettings.Activated += OnClickSettings;
			menuItemQuit.Activated += OnClickExit;

			popupMenu.ShowAll ();
			popupMenu.Popup ();
		}
			
		public void OnClickSettings (object sender, EventArgs e)
		{
			winSettings.Show ();
		}
			
		public void OnClickExit(object sender, EventArgs e)
		{
			Application.Quit ();
		}

		#endregion

	}
}

