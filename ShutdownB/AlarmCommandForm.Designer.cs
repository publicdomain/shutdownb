
namespace ShutdownB
{
    partial class AlarmCommandForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.argumentsLabel = new System.Windows.Forms.Label();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.setAlarmCommandButton = new System.Windows.Forms.Button();
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.argumentsTextBox = new System.Windows.Forms.TextBox();
            this.isHiddencheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.argumentsLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.filePathLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.setAlarmCommandButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.filePathTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.argumentsTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.isHiddencheckBox, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(430, 103);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // argumentsLabel
            // 
            this.argumentsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.argumentsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.argumentsLabel.Location = new System.Drawing.Point(3, 34);
            this.argumentsLabel.Name = "argumentsLabel";
            this.argumentsLabel.Size = new System.Drawing.Size(101, 34);
            this.argumentsLabel.TabIndex = 8;
            this.argumentsLabel.Text = "Arguments:";
            this.argumentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // filePathLabel
            // 
            this.filePathLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filePathLabel.Location = new System.Drawing.Point(3, 0);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(101, 34);
            this.filePathLabel.TabIndex = 0;
            this.filePathLabel.Text = "File path:";
            this.filePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setAlarmCommandButton
            // 
            this.setAlarmCommandButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setAlarmCommandButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setAlarmCommandButton.Location = new System.Drawing.Point(110, 71);
            this.setAlarmCommandButton.Name = "setAlarmCommandButton";
            this.setAlarmCommandButton.Size = new System.Drawing.Size(317, 29);
            this.setAlarmCommandButton.TabIndex = 5;
            this.setAlarmCommandButton.Text = "&Set alarm command";
            this.setAlarmCommandButton.UseVisualStyleBackColor = true;
            this.setAlarmCommandButton.Click += new System.EventHandler(this.OnSetAlarmCommandButtonClick);
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePathTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.filePathTextBox.Location = new System.Drawing.Point(110, 3);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(317, 26);
            this.filePathTextBox.TabIndex = 6;
            // 
            // argumentsTextBox
            // 
            this.argumentsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.argumentsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.argumentsTextBox.Location = new System.Drawing.Point(110, 37);
            this.argumentsTextBox.Name = "argumentsTextBox";
            this.argumentsTextBox.Size = new System.Drawing.Size(317, 26);
            this.argumentsTextBox.TabIndex = 7;
            // 
            // isHiddencheckBox
            // 
            this.isHiddencheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.isHiddencheckBox.Location = new System.Drawing.Point(3, 71);
            this.isHiddencheckBox.Name = "isHiddencheckBox";
            this.isHiddencheckBox.Size = new System.Drawing.Size(101, 24);
            this.isHiddencheckBox.TabIndex = 9;
            this.isHiddencheckBox.Text = "&Hidden";
            this.isHiddencheckBox.UseVisualStyleBackColor = true;
            // 
            // AlarmCommandForm
            // 
            this.AcceptButton = this.setAlarmCommandButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 103);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "AlarmCommandForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Alarm command";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnAlarmCommandFormKeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.CheckBox isHiddencheckBox;
        private System.Windows.Forms.TextBox argumentsTextBox;
        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label argumentsLabel;
        private System.Windows.Forms.Button setAlarmCommandButton;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
