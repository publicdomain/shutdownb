
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShutdownB
{
    /// <summary>
    /// Description of CustomTimeSpanForm.
    /// </summary>
    public partial class CustomTimeSpanForm : Form
    {
        /// <summary>
        /// The main form.
        /// </summary>
        private MainForm mainForm;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ShutdownB.CustomTimeSpanForm"/> class.
        /// </summary>
        /// <param name="mainForm">Main form.</param>
        public CustomTimeSpanForm(MainForm mainForm)
        {
            // Set the main form
            this.mainForm = mainForm;

            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();
        }

        /// <summary>
        /// Handles the set custom time button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSetCustomTimeButtonClick(object sender, EventArgs e)
        {
            // Set the timespan on passed main form
            this.mainForm.CustomTimeSpan = new TimeSpan((int)this.hourNumericUpDown.Value, (int)this.minuteNumericUpDown.Value, (int)this.secondNumericUpDown.Value);

            // Close the form
            this.Close();
        }

        /// <summary>
        /// Handles the custom time span form form closing.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCustomTimeSpanFormFormClosing(object sender, FormClosingEventArgs e)
        {
            // TODO Add code if needed
        }
    }
}
