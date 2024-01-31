// <copyright file="MainForm.cs" company="Paradisus.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Forms;
using System.Reflection;
using PublicDomain;

namespace ShutdownB
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Gets or sets the associated icon.
        /// </summary>
        /// <value>The associated icon.</value>
        private Icon associatedIcon = null;

        /// <summary>
        /// Gets the cursor position.
        /// </summary>
        /// <returns><c>true</c>, if cursor position was gotten, <c>false</c> otherwise.</returns>
        /// <param name="lpPoint">Lp point.</param>
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        /// <summary>
        /// Locks the work station.
        /// </summary>
        [DllImport("user32")]
        public static extern void LockWorkStation();

        /// <summary>
        /// Exits the windows ex.
        /// </summary>
        /// <returns><c>true</c>, if windows ex was exited, <c>false</c> otherwise.</returns>
        /// <param name="uFlags">U flags.</param>
        /// <param name="dwReason">Dw reason.</param>
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ShutdownB.MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            this.InitializeComponent();

            /* Set icons */

            // Set associated icon from exe file
            this.associatedIcon = Icon.ExtractAssociatedIcon(typeof(MainForm).GetTypeInfo().Assembly.Location);
        }

        private void OnContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        /// <summary>
        /// Handles the main form load.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnMainFormLoad(object sender, EventArgs e)
        {
            // Declare the cursor point
            var cursorPoint = new Point();

            // Poplate it
            GetCursorPos(ref cursorPoint);

            // Show the context menu strips
            this.mainContextMenuStrip.Show(cursorPoint.X, cursorPoint.Y);
        }

        private void OnMainFormShown(object sender, EventArgs e)
        {

        }

        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {

        }

        /// <summary>
        /// Handles the shut down tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnShutDownToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue command
            Process.Start("shutdown", "/s /t 0");
        }

        /// <summary>
        /// Ons the hibernate tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHibernateToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Ons the lock tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLockToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue command
            LockWorkStation();
        }

        /// <summary>
        /// Ons the log off tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLogOffToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue command
            ExitWindowsEx(0, 0);
        }

        /// <summary>
        /// Ons the sleep tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSleepToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handle the restart tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRestartToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue command
            Process.Start("shutdown", "/r /t 0");
        }

        private void OnTimerToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OnAlarmToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void OnSettingsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        /// <summary>
        /// Handles the about tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Set license text
            var licenseText = $"CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication{Environment.NewLine}" +
                $"https://creativecommons.org/publicdomain/zero/1.0/legalcode{Environment.NewLine}{Environment.NewLine}" +
                $"Libraries and icons have separate licenses.{Environment.NewLine}{Environment.NewLine}" +
                $"SharpClipboard by Willy-Kimura - MIT License{Environment.NewLine}" +
                $"https://github.com/Willy-Kimura/SharpClipboard{Environment.NewLine}{Environment.NewLine}" +
                $"Clipboard-paper icon by OpenClipart-Vectors - Pixabay's Content license{Environment.NewLine}" +
                $"https://pixabay.com/vectors/icon-icons-matt-shutdown-symbol-1294532/{Environment.NewLine}{Environment.NewLine}" +
                $"Buttons icon by Clker-Free-Vector-Images - Pixabay's Content license{Environment.NewLine}" +
                $"https://pixabay.com/vectors/buttons-stop-play-pause-record-35531/{Environment.NewLine}{Environment.NewLine}" +
                $"Patreon icon used according to published brand guidelines{Environment.NewLine}" +
                $"https://www.patreon.com/brand{Environment.NewLine}{Environment.NewLine}" +
                $"GitHub mark icon used according to published logos and usage guidelines{Environment.NewLine}" +
                $"https://github.com/logos{Environment.NewLine}{Environment.NewLine}" +
                $"DonationCoder icon used with permission{Environment.NewLine}" +
                $"https://www.donationcoder.com/forum/index.php?topic=48718{Environment.NewLine}{Environment.NewLine}" +
                $"PublicDomain icon is based on the following source images:{Environment.NewLine}{Environment.NewLine}" +
                $"Bitcoin by GDJ - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/vectors/bitcoin-digital-currency-4130319/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter P by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/p-glamour-gold-lights-2790632/{Environment.NewLine}{Environment.NewLine}" +
                $"Letter D by ArtsyBee - Pixabay License{Environment.NewLine}" +
                $"https://pixabay.com/illustrations/d-glamour-gold-lights-2790573/{Environment.NewLine}{Environment.NewLine}";

            // Set title
            string programTitle = typeof(MainForm).GetTypeInfo().Assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title;

            // Set version for generating semantic version
            Version version = typeof(MainForm).GetTypeInfo().Assembly.GetName().Version;

            // Set about form
            var aboutForm = new AboutForm(
                $"About {programTitle}",
                $"{programTitle} {version.Major}.{version.Minor}.{version.Build}",
                $"Made for: luvnbeast{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #031, Week #05 @ January 31, 2024",
                licenseText,
                this.Icon.ToBitmap())
            {
                // Set about form icon
                Icon = this.associatedIcon,

                // Set always on top
                TopMost = this.TopMost
            };

            // Show about form
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Handles the cancel button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            // Close program        
            this.Close();
        }

        private void OnSubtractButtonClick(object sender, EventArgs e)
        {

        }

        private void OnAddButtonClick(object sender, EventArgs e)
        {

        }

        private void OnActionComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the options tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOptionsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set tool strip menu item
            ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)e.ClickedItem;

            // Toggle checked
            toolStripMenuItem.Checked = !toolStripMenuItem.Checked;

            // Set topmost by check box
            this.TopMost = this.alwaysOnTopToolStripMenuItem.Checked;
        }

        /// <summary>
        /// Handles the original thread donation codercom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnOriginalThreadDonationCodercomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open original thread
            Process.Start("https://www.donationcoder.com/forum/index.php?topic=53917.0");
        }

        /// <summary>
        /// Handles the source code githubcom tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSourceCodeGithubcomToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Open GitHub repository
            Process.Start("https://github.com/publicdomain/shutdownb/");
        }

        /// <summary>
        /// Handles the exit tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Close program        
            this.Close();
        }

    }
}
