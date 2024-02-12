
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ShutdownB
{
    /// <summary>
    /// Description of AlarmCommandForm.
    /// </summary>
    public partial class AlarmCommandForm : Form
    {
        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        /// <value>The file path.</value>
        public string FilePath { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        /// <value>The arguments.</value>
        public string Arguments { get; set; } = String.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="T:ShutdownB.AlarmCommandForm"/> is hidden.
        /// </summary>
        /// <value><c>true</c> if is hidden; otherwise, <c>false</c>.</value>
        public bool IsHidden { get; set; } = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:ShutdownB.AlarmCommandForm"/> class.
        /// </summary>
        /// <param name="filePath">File path.</param>
        /// <param name="arguments">Arguments.</param>
        /// <param name="isHidden">If set to <c>true</c> is hidden.</param>
        public AlarmCommandForm(string filePath, string arguments, bool isHidden)
        {
            // The InitializeComponent() call is required for Windows Forms designer support.
            this.InitializeComponent();

            // Set values into form
            this.filePathTextBox.Text = filePath;
            this.argumentsTextBox.Text = arguments;
            this.isHiddencheckBox.Checked = isHidden;
        }

        /// <summary>
        /// Handles the set alarm command button click.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnSetAlarmCommandButtonClick(object sender, EventArgs e)
        {
            // Check file path's length
            if (this.filePathTextBox.Text.Length > 0)
            {
                // Set instance values
                this.FilePath = this.filePathTextBox.Text;
                this.Arguments = this.argumentsTextBox.Text;
                this.IsHidden = this.isHiddencheckBox.Checked;

                // Set dialog result
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                // Set dialog result
                this.DialogResult = DialogResult.Cancel;
            }

            // Close the form
            this.Close();
        }

        /// <summary>
        /// Handles the alarm command form key down.
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAlarmCommandFormKeyDown(object sender, KeyEventArgs e)
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
