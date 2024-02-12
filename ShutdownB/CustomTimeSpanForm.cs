
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
        /// Gets or sets the custom time span.
        /// </summary>
        /// <value>The custom time span.</value>
        public TimeSpan CustomTimeSpan { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ShutdownB.CustomTimeSpanForm"/> class.
        /// </summary>
        public CustomTimeSpanForm(TimeSpan customTimeSpan)
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set the custom timespan
            this.CustomTimeSpan = customTimeSpan;

            // Set the passed values
            this.hourNumericUpDown.Value = this.CustomTimeSpan.Hours;
            this.minuteNumericUpDown.Value = this.CustomTimeSpan.Minutes;
            this.secondNumericUpDown.Value = this.CustomTimeSpan.Seconds;
        }

        /// <summary>
        /// Handles the set custom time button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSetCustomTimeButtonClick(object sender, EventArgs e)
        {
            // Set the custom timespan 
            this.CustomTimeSpan = new TimeSpan((int)this.hourNumericUpDown.Value, (int)this.minuteNumericUpDown.Value, (int)this.secondNumericUpDown.Value);

            // Set dialog result
            this.DialogResult = DialogResult.OK;

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

        /// <summary>
        /// Handles the custom time span form key down.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnCustomTimeSpanFormKeyDown(object sender, KeyEventArgs e)
        {
            // Check for escape
            if (e.KeyCode == Keys.Escape)
            {
                // Close the program
                Application.Exit();
            }
        }
    }
}
