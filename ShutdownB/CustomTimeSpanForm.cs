
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
        public CustomTimeSpanForm()
        {
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
            this.CustomTimeSpan = new TimeSpan((int)this.hourNumericUpDown.Value, (int)this.minuteNumericUpDown.Value, (int)this.secondNumericUpDown.Value);

            // Set dialog result
            this.DialogResult = DialogResult.OK;

            // Close the form
            this.Close();
        }

        /// <summary>
        /// Processes the dialog key.
        /// </summary>
        /// <returns><c>true</c>, if dialog key was processed, <c>false</c> otherwise.</returns>
        /// <param name="keyData">Key data.</param>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
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
