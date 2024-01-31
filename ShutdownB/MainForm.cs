// <copyright file="MainForm.cs" company="Paradisus.is">
//     CC0 1.0 Universal (CC0 1.0) - Public Domain Dedication
//     https://creativecommons.org/publicdomain/zero/1.0/legalcode
// </copyright>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Forms;

namespace ShutdownB
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool GetCursorPos(ref Point lpPoint);

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();
        }

        private void OnContextMenuStripOpening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void OnMainFormLoad(object sender, EventArgs e)
        {
            var cursorPoint = new Point();

            GetCursorPos(ref cursorPoint);

            this.mainContextMenuStrip.Show(cursorPoint.X, cursorPoint.Y);
        }

        private void OnMainFormShown(object sender, EventArgs e)
        {

        }

        private void OnMainFormFormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void OnShutDownToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnHibernateToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnLockToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnLogOffToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnSleepToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnRestartToolStripMenuItemClick(object sender, EventArgs e)
        {

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

        private void OnAboutToolStripMenuItemClick(object sender, EventArgs e)
        {

        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {

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

        private void OnExitToolStripMenuItemClick(object sender, EventArgs e)
        {

        }
    }
}
