
namespace Alarm501
{
    partial class TimeAddr
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.timePicker = new System.Windows.Forms.DateTimePicker();
            this.confirmButton = new System.Windows.Forms.Button();
            this.disabledCheckBox = new System.Windows.Forms.CheckBox();
            this.alarmTonePicker = new System.Windows.Forms.ComboBox();
            this.snoozeTime = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.snoozeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // timePicker
            // 
            this.timePicker.CustomFormat = "hh:mm:ss tt";
            this.timePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.timePicker.Location = new System.Drawing.Point(75, 48);
            this.timePicker.Name = "timePicker";
            this.timePicker.ShowUpDown = true;
            this.timePicker.Size = new System.Drawing.Size(200, 20);
            this.timePicker.TabIndex = 0;
            this.timePicker.ValueChanged += new System.EventHandler(this.timePicker_ValueChanged);
            // 
            // confirmButton
            // 
            this.confirmButton.Location = new System.Drawing.Point(315, 106);
            this.confirmButton.Name = "confirmButton";
            this.confirmButton.Size = new System.Drawing.Size(75, 23);
            this.confirmButton.TabIndex = 1;
            this.confirmButton.Text = "Confirm";
            this.confirmButton.UseVisualStyleBackColor = true;
            this.confirmButton.Click += new System.EventHandler(this.confirmButton_Click);
            // 
            // disabledCheckBox
            // 
            this.disabledCheckBox.AutoSize = true;
            this.disabledCheckBox.Location = new System.Drawing.Point(281, 48);
            this.disabledCheckBox.Name = "disabledCheckBox";
            this.disabledCheckBox.Size = new System.Drawing.Size(67, 17);
            this.disabledCheckBox.TabIndex = 2;
            this.disabledCheckBox.Text = "Disabled";
            this.disabledCheckBox.UseVisualStyleBackColor = true;
            // 
            // alarmTonePicker
            // 
            this.alarmTonePicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.alarmTonePicker.FormattingEnabled = true;
            this.alarmTonePicker.Location = new System.Drawing.Point(75, 82);
            this.alarmTonePicker.Name = "alarmTonePicker";
            this.alarmTonePicker.Size = new System.Drawing.Size(102, 21);
            this.alarmTonePicker.TabIndex = 3;
            this.alarmTonePicker.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // snoozeTime
            // 
            this.snoozeTime.Location = new System.Drawing.Point(209, 82);
            this.snoozeTime.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.snoozeTime.Name = "snoozeTime";
            this.snoozeTime.Size = new System.Drawing.Size(66, 20);
            this.snoozeTime.TabIndex = 4;
            // 
            // TimeAddr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.snoozeTime);
            this.Controls.Add(this.alarmTonePicker);
            this.Controls.Add(this.disabledCheckBox);
            this.Controls.Add(this.confirmButton);
            this.Controls.Add(this.timePicker);
            this.Name = "TimeAddr";
            this.Size = new System.Drawing.Size(393, 132);
            this.Load += new System.EventHandler(this.TimeAddr_Load);
            ((System.ComponentModel.ISupportInitialize)(this.snoozeTime)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker timePicker;
        private System.Windows.Forms.Button confirmButton;
        private System.Windows.Forms.CheckBox disabledCheckBox;
        private System.Windows.Forms.ComboBox alarmTonePicker;
        private System.Windows.Forms.NumericUpDown snoozeTime;
    }
}
