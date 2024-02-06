
namespace ShutdownB
{
    partial class CustomTimeSpanForm
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
            this.secondNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minuteNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hourNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minuteSecondSeparatorLabel = new System.Windows.Forms.Label();
            this.hourMinuteSeparatorLabel = new System.Windows.Forms.Label();
            this.timeSpanFormatLabel = new System.Windows.Forms.Label();
            this.setCustomTimeButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.secondNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.Controls.Add(this.secondNumericUpDown, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.minuteNumericUpDown, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.hourNumericUpDown, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.minuteSecondSeparatorLabel, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.hourMinuteSeparatorLabel, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.timeSpanFormatLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.setCustomTimeButton, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(259, 106);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // secondNumericUpDown
            // 
            this.secondNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.secondNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.secondNumericUpDown.Location = new System.Drawing.Point(181, 38);
            this.secondNumericUpDown.Maximum = new decimal(new int[] {
                                    59,
                                    0,
                                    0,
                                    0});
            this.secondNumericUpDown.Name = "secondNumericUpDown";
            this.secondNumericUpDown.Size = new System.Drawing.Size(75, 22);
            this.secondNumericUpDown.TabIndex = 10;
            this.secondNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minuteNumericUpDown
            // 
            this.minuteNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minuteNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuteNumericUpDown.Location = new System.Drawing.Point(92, 38);
            this.minuteNumericUpDown.Maximum = new decimal(new int[] {
                                    59,
                                    0,
                                    0,
                                    0});
            this.minuteNumericUpDown.Name = "minuteNumericUpDown";
            this.minuteNumericUpDown.Size = new System.Drawing.Size(73, 22);
            this.minuteNumericUpDown.TabIndex = 9;
            this.minuteNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minuteNumericUpDown.Value = new decimal(new int[] {
                                    15,
                                    0,
                                    0,
                                    0});
            // 
            // hourNumericUpDown
            // 
            this.hourNumericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hourNumericUpDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourNumericUpDown.Location = new System.Drawing.Point(3, 38);
            this.hourNumericUpDown.Maximum = new decimal(new int[] {
                                    23,
                                    0,
                                    0,
                                    0});
            this.hourNumericUpDown.Name = "hourNumericUpDown";
            this.hourNumericUpDown.Size = new System.Drawing.Size(73, 22);
            this.hourNumericUpDown.TabIndex = 8;
            this.hourNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minuteSecondSeparatorLabel
            // 
            this.minuteSecondSeparatorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.minuteSecondSeparatorLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.minuteSecondSeparatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuteSecondSeparatorLabel.Location = new System.Drawing.Point(168, 35);
            this.minuteSecondSeparatorLabel.Margin = new System.Windows.Forms.Padding(0);
            this.minuteSecondSeparatorLabel.Name = "minuteSecondSeparatorLabel";
            this.minuteSecondSeparatorLabel.Size = new System.Drawing.Size(10, 35);
            this.minuteSecondSeparatorLabel.TabIndex = 7;
            this.minuteSecondSeparatorLabel.Text = ":";
            this.minuteSecondSeparatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hourMinuteSeparatorLabel
            // 
            this.hourMinuteSeparatorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hourMinuteSeparatorLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.hourMinuteSeparatorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourMinuteSeparatorLabel.Location = new System.Drawing.Point(79, 35);
            this.hourMinuteSeparatorLabel.Margin = new System.Windows.Forms.Padding(0);
            this.hourMinuteSeparatorLabel.Name = "hourMinuteSeparatorLabel";
            this.hourMinuteSeparatorLabel.Size = new System.Drawing.Size(10, 35);
            this.hourMinuteSeparatorLabel.TabIndex = 6;
            this.hourMinuteSeparatorLabel.Text = ":";
            this.hourMinuteSeparatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeSpanFormatLabel
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.timeSpanFormatLabel, 5);
            this.timeSpanFormatLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeSpanFormatLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeSpanFormatLabel.Location = new System.Drawing.Point(3, 0);
            this.timeSpanFormatLabel.Name = "timeSpanFormatLabel";
            this.timeSpanFormatLabel.Size = new System.Drawing.Size(253, 35);
            this.timeSpanFormatLabel.TabIndex = 0;
            this.timeSpanFormatLabel.Text = "Hours : Minutes : Seconds";
            this.timeSpanFormatLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // setCustomTimeButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.setCustomTimeButton, 5);
            this.setCustomTimeButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.setCustomTimeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setCustomTimeButton.Location = new System.Drawing.Point(3, 73);
            this.setCustomTimeButton.Name = "setCustomTimeButton";
            this.setCustomTimeButton.Size = new System.Drawing.Size(253, 30);
            this.setCustomTimeButton.TabIndex = 4;
            this.setCustomTimeButton.Text = "&Set custom time";
            this.setCustomTimeButton.UseVisualStyleBackColor = true;
            this.setCustomTimeButton.Click += new System.EventHandler(this.OnSetCustomTimeButtonClick);
            // 
            // CustomTimeSpanForm
            // 
            this.AcceptButton = this.setCustomTimeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 106);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "CustomTimeSpanForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set custom time";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnCustomTimeSpanFormFormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.secondNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuteNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hourNumericUpDown)).EndInit();
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.NumericUpDown secondNumericUpDown;
        private System.Windows.Forms.NumericUpDown minuteNumericUpDown;
        private System.Windows.Forms.NumericUpDown hourNumericUpDown;
        private System.Windows.Forms.Label minuteSecondSeparatorLabel;
        private System.Windows.Forms.Label hourMinuteSeparatorLabel;
        private System.Windows.Forms.Button setCustomTimeButton;
        private System.Windows.Forms.Label timeSpanFormatLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
