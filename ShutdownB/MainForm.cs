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
using System.IO;

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
        /// The settings data.
        /// </summary>
        private SettingsData settingsData = null;

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
        /// Sets the state of the suspend.
        /// </summary>
        /// <returns><c>true</c>, if suspend state was set, <c>false</c> otherwise.</returns>
        /// <param name="hiberate">If set to <c>true</c> hiberate.</param>
        /// <param name="forceCritical">If set to <c>true</c> force critical.</param>
        /// <param name="disableWakeEvent">If set to <c>true</c> disable wake event.</param>
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);

        /// <summary>
        /// Exits the windows ex.
        /// </summary>
        /// <returns><c>true</c>, if windows ex was exited, <c>false</c> otherwise.</returns>
        /// <param name="uFlags">U flags.</param>
        /// <param name="dwReason">Dw reason.</param>
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);

        /// <summary>
        /// The action timer.
        /// </summary>
        private System.Timers.Timer actionTimer;

        /// <summary>
        /// The action start date time.
        /// </summary>
        private DateTime actionSetDateTime;

        /// <summary>
        /// The actio run date time.
        /// </summary>
        private DateTime actionRunDateTime;

        /// <summary>
        /// The name of the action.
        /// </summary>
        private string actionName;

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

            /* Settings */

            // Set the settings data
            this.settingsData = new SettingsData(Path.Combine(Application.StartupPath, $"{ Application.ProductName }-SettingsData.txt"), false);

            // Set TIMP executable path
            string timpExecutablePath = Path.Combine(Application.StartupPath, "TIMP.exe");

            // Check for TIMP
            if (this.settingsData.ProcessFileName.Length == 0 && File.Exists(timpExecutablePath))
            {
                // Set TIMP process properties
                this.settingsData.ProcessFileName = timpExecutablePath;
                this.settingsData.ProcessArguments = "/play current";
            }

            /* Set timer */

            // Create a timer and set a two second interval.
            this.actionTimer = new System.Timers.Timer
            {
                Interval = 250 // Four times per second
            };

            // Hook the event up
            this.actionTimer.Elapsed += OnTimedEvent;

            // Explicitly fire repeated events
            this.actionTimer.AutoReset = true;
        }

        /// <summary>
        /// Handles the timed event.
        /// </summary>
        /// <param name="source">Source.</param>
        /// <param name="e">Elapsed event arguments.</param>
        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Set the timer label
            this.SetTimerLabel();

            // Check if it's time to run
            if (DateTime.Now >= this.actionRunDateTime)
            {
                // TODO Disable the action timer [Zero it as well]
                this.actionTimer.Enabled = false;

                // Check for alarm by combobox's disabled status
                if (this.actionComboBox.Enabled == false)
                {
                    // Check there's a command to run
                    if (this.settingsData.ProcessFileName.Length > 0)
                    {
                        // Confirm the program file is present
                        if (File.Exists(this.settingsData.ProcessFileName))
                        {
                            try
                            {
                                // Set alarm's process
                                Process process = new Process();

                                // Set file name
                                process.StartInfo.FileName = this.settingsData.ProcessFileName;

                                // Check for arguments
                                if (this.settingsData.ProcessArguments.Length > 0)
                                {
                                    // Set the arguments
                                    process.StartInfo.Arguments = this.settingsData.ProcessArguments;
                                }

                                // Check if it's hidden
                                if (this.settingsData.ProcessIsHidden)
                                {
                                    // Set window style
                                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                }

                                // Start the alarm process
                                process.Start();
                            }
                            catch (Exception ex)
                            {
                                // Advise user
                                MessageBox.Show(ex.Message, "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            // Advise user
                            MessageBox.Show("Alarm command file does not exist.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }

                    }
                    else
                    {
                        // Advise user
                        MessageBox.Show("Alarm command is not set.", "Alarm", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    // Run the action
                    switch (this.actionComboBox.Text)
                    {
                        case "Shut down":
                            this.ShutdownNow();

                            break;

                        case "Hibernate":
                            this.HibernateNow();

                            break;

                        case "Lock":
                            this.LockNow();

                            break;
                        case "Log off":
                            this.LogoffNow();

                            break;

                        case "Sleep":
                            this.SleepNow();

                            break;

                        case "Restart":
                            this.RestartNow();

                            break;
                    }
                }

                // Exit the program
                this.Close();
            }
        }

        /// <summary>
        /// Sets the timer label.
        /// </summary>
        private void SetTimerLabel()
        {
            // Advise: action + time left to run it
            this.timerLabel.Text = $"{this.actionName} {((DateTime.Now >= this.actionRunDateTime) ? "00:00:00" : (this.actionRunDateTime - DateTime.Now).ToString(@"hh\:mm\:ss"))}";
        }

        /// <summary>
        /// Sets the action.
        /// </summary>
        /// <param name="actionName">Action name.</param>
        /// <param name="hours">Hours.</param>
        /// <param name="minutes">Minutes.</param>
        /// <param name="seconds">Seconds.</param>
        private void SetAction(string actionName, int hours, int minutes, int seconds)
        {
            // Enable table layout panel
            this.tableLayoutPanel1.Enabled = true;

            // Set the action name
            this.actionName = actionName;

            // Set DateTime objects
            this.actionSetDateTime = DateTime.Now;
            this.actionRunDateTime = this.actionSetDateTime.AddHours(hours).AddMinutes(minutes).AddSeconds(seconds);

            // TODO Check for alarm [Enabling and disabling can be more elaborate]
            if (actionName == "Alarm")
            {
                // Deselect and disable the action combo box
                this.actionComboBox.SelectedIndex = -1;
                this.actionComboBox.Enabled = false;
            }
            else
            {
                // Enable and set action combo box to matching item
                this.actionComboBox.Enabled = true;
                this.actionComboBox.SelectedIndex = this.actionComboBox.FindStringExact(actionName);
            }

            // Update the happening at label
            this.UpdateHappeningAtLabel();

            // Set the timer label
            this.SetTimerLabel();

            // Start the action timer
            this.actionTimer.Enabled = true;

            // Bring us to the fore
            this.WindowState = FormWindowState.Normal;
        }

        /// <summary>
        /// Updates the happening at label.
        /// </summary>
        private void UpdateHappeningAtLabel()
        {
            // Update "happening at" value
            this.happeningAtValueToolStripStatusLabel.Text = this.actionRunDateTime.ToString();
        }

        /// <summary>
        /// Handles the context menu strip opening.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // TODO Add code if needed
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

            // TODO Show the context menu strip [Can be replaced by ContextMenu]
            this.mainContextMenuStrip.Show(cursorPoint.X, cursorPoint.Y);
        }

        /// <summary>
        /// Handles the main form shown.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnMainFormShown(object sender, EventArgs e)
        {
            // TODO Add code if needed
        }

        /// <summary>
        /// Handles the main form form closing.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // Save settings file
            this.settingsData.SaveSettingsFile();
        }

        /// <summary>
        /// Handles the shut down tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnShutDownToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue shut down
            this.ShutdownNow();
        }

        /// <summary>
        /// Shutdowns immediately.
        /// </summary>
        private void ShutdownNow()
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "/s /t 0";
            process.Start();
        }

        /// <summary>
        /// Handles the hibernate tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnHibernateToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue hibernation
            this.HibernateNow();

        }

        /// <summary>
        /// Hibernates immediately.
        /// </summary>
        private void HibernateNow()
        {
            SetSuspendState(true, true, true);
        }

        /// <summary>
        /// Handles the sleep tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSleepToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue sleep command
            this.SleepNow();
        }

        /// <summary>
        /// Sleeps immediately.
        /// </summary>
        private void SleepNow()
        {
            SetSuspendState(false, true, true);
        }

        /// <summary>
        /// Handles the lock tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLockToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue lock
            this.LockNow();
        }

        /// <summary>
        /// Locks immediately.
        /// </summary>
        private void LockNow()
        {
            LockWorkStation();
        }

        /// <summary>
        /// Handles the log off tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnLogOffToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue log off command
            this.LogoffNow();
        }

        /// <summary>
        /// Logs off immediately.
        /// </summary>
        private void LogoffNow()
        {
            ExitWindowsEx(0, 0);
        }

        /// <summary>
        /// Handle the restart tool strip menu item click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnRestartToolStripMenuItemClick(object sender, EventArgs e)
        {
            // Issue restart
            this.RestartNow();
        }

        /// <summary>
        /// Restarts immediately.
        /// </summary>
        private void RestartNow()
        {
            Process process = new Process();
            process.StartInfo.FileName = "shutdown";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.StartInfo.Arguments = "/r /t 0";
            process.Start();
        }

        /// <summary>
        /// Handles the timer tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnTimerToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set the time 
            string[] senderTime = ((ToolStripMenuItem)sender).Text.Replace("&", string.Empty).Split(new char[] { ' ' });

            // Set the action
            string actionName = e.ClickedItem.Text.Replace("&", string.Empty);

            // Set the time integers
            int hours = 0, minutes = 0, seconds = 0;

            // Switch sender time's hours/minutes
            switch (senderTime[1])
            {
                // Hour(s)
                case "hour":
                case "hours":

                    // Set
                    hours = int.Parse(senderTime[0]);

                    break;

                // Minutes
                case "minutes":

                    // Set
                    minutes = int.Parse(senderTime[0]);

                    break;

                // Custom
                default:
                    // Open the custom time dialog
                    using (var customTimeSpanForm = new CustomTimeSpanForm(new TimeSpan(this.settingsData.DefaultHours, this.settingsData.DefaultMinutes, this.settingsData.DefaultSeconds)))
                    {
                        // Show the dialog and check result
                        if (customTimeSpanForm.ShowDialog() != DialogResult.OK)
                        {
                            // Halt program's flow
                            this.Close();
                            return;
                        }

                        // Set
                        hours = customTimeSpanForm.CustomTimeSpan.Hours;
                        minutes = customTimeSpanForm.CustomTimeSpan.Minutes;
                        seconds = customTimeSpanForm.CustomTimeSpan.Seconds;
                    }

                    break;
            }

            // Set the action
            this.SetAction(actionName, hours, minutes, seconds);
        }

        /// <summary>
        /// Handles the alarm tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        private void OnAlarmToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set the time integers
            int hours = 0, minutes = 0, seconds = 0;

            // Switch by name
            switch (e.ClickedItem.Name)
            {
                // 10 minutes
                case "soundIn10MinutesToolStripMenuItem":
                    minutes = 10;

                    break;

                // 30 minutes
                case "soundIn30MinutesToolStripMenuItem":
                    minutes = 30;

                    break;

                // 1 hour
                case "soundIn1HourToolStripMenuItem":
                    hours = 1;

                    break;

                // 2 hours
                case "soundIn2HoursToolStripMenuItem":
                    hours = 2;

                    break;

                // Custom time
                case "soundInCustomTimeToolStripMenuItem":

                    // Open the custom time dialog
                    using (var customTimeSpanForm = new CustomTimeSpanForm(new TimeSpan(this.settingsData.DefaultHours, this.settingsData.DefaultMinutes, this.settingsData.DefaultSeconds)))
                    {
                        // Show the dialog and check result
                        if (customTimeSpanForm.ShowDialog() != DialogResult.OK)
                        {
                            // Halt program's flow
                            this.Close();
                            return;
                        }

                        // Set
                        hours = customTimeSpanForm.CustomTimeSpan.Hours;
                        minutes = customTimeSpanForm.CustomTimeSpan.Minutes;
                        seconds = customTimeSpanForm.CustomTimeSpan.Seconds;
                    }

                    break;
            }

            // Set the action
            this.SetAction("Alarm", hours, minutes, seconds);
        }

        /// <summary>
        /// Handles the settings tool strip menu item drop down item clicked.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSettingsToolStripMenuItemDropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Switch by name
            switch (e.ClickedItem.Name)
            {
                // Alarm command
                case "alarmSoundCommandToolStripMenuItem":
                case "alarmSoundCommandToolStripMenuItem1":
                    // Open the alarm command dialog
                    using (var alarmCommandForm = new AlarmCommandForm(this.settingsData.ProcessFileName, this.settingsData.ProcessArguments, this.settingsData.ProcessIsHidden))
                    {
                        // Set the icon
                        alarmCommandForm.Icon = this.Icon;

                        // Show the dialog and check result
                        if (alarmCommandForm.ShowDialog() == DialogResult.OK)
                        {
                            // Set into settings
                            this.settingsData.ProcessFileName = alarmCommandForm.FilePath;
                            this.settingsData.ProcessArguments = alarmCommandForm.Arguments;
                            this.settingsData.ProcessIsHidden = alarmCommandForm.IsHidden;
                        }
                    }

                    // Check if must close
                    if (e.ClickedItem.Name == "alarmSoundCommandToolStripMenuItem")
                    {
                        // Exit program
                        this.Close();
                    }

                    break;

                // Default custom time
                case "defaultCustomTimeToolStripMenuItem":
                case "defaultCustomTimeToolStripMenuItem1":

                    // Open the custom time dialog
                    using (var customTimeSpanForm = new CustomTimeSpanForm(new TimeSpan(this.settingsData.DefaultHours, this.settingsData.DefaultMinutes, this.settingsData.DefaultSeconds)))
                    {
                        // Set the icon
                        customTimeSpanForm.Icon = this.Icon;

                        // Show the dialog and check result
                        if (customTimeSpanForm.ShowDialog() == DialogResult.OK)
                        {
                            // Set into settings
                            this.settingsData.DefaultHours = customTimeSpanForm.CustomTimeSpan.Hours;
                            this.settingsData.DefaultMinutes = customTimeSpanForm.CustomTimeSpan.Minutes;
                            this.settingsData.DefaultSeconds = customTimeSpanForm.CustomTimeSpan.Seconds;
                        }
                    }

                    // Check if must close
                    if (e.ClickedItem.Name == "defaultCustomTimeToolStripMenuItem")
                    {
                        // Exit program
                        this.Close();
                    }

                    break;
            }
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
                $"Made for: luvnbeast{Environment.NewLine}DonationCoder.com{Environment.NewLine}Day #051, Week #08 @ February 20, 2024",
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

        /// <summary>
        /// Handles the subtract button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSubtractButtonClick(object sender, EventArgs e)
        {
            // Subtract current values
            this.actionRunDateTime = this.actionRunDateTime
                .Subtract(TimeSpan.FromHours((int)this.hourNumericUpDown.Value))
                .Subtract(TimeSpan.FromMinutes((int)this.minuteNumericUpDown.Value))
                .Subtract(TimeSpan.FromSeconds((int)this.secondNumericUpDown.Value));


            // Update the happening at label
            this.UpdateHappeningAtLabel();

            // Set the timer label
            this.SetTimerLabel();
        }

        /// <summary>
        /// Handles the add button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAddButtonClick(object sender, EventArgs e)
        {
            // Add current values
            this.actionRunDateTime = this.actionRunDateTime
            .AddHours((int)this.hourNumericUpDown.Value)
            .AddMinutes((int)this.minuteNumericUpDown.Value)
            .AddSeconds((int)this.secondNumericUpDown.Value);

            // Update the happening at label
            this.UpdateHappeningAtLabel();

            // Set the label immediately
            this.SetTimerLabel();
        }

        /// <summary>
        /// Handles the action combo box selected index changed.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnActionComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            // Update action
            this.actionName = this.actionComboBox.GetItemText(actionComboBox.SelectedItem); ;

            // Set the label immediately
            this.SetTimerLabel();
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
