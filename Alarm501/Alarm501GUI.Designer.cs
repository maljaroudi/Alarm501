
namespace Alarm501
{
    partial class alarmGUI
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.alarmsList = new System.Windows.Forms.ListBox();
            this.addButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.statusText = new System.Windows.Forms.TextBox();
            this.snoozeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.currentAlarmStatus = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // alarmsList
            // 
            this.alarmsList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.alarmsList.FormattingEnabled = true;
            this.alarmsList.Location = new System.Drawing.Point(12, 114);
            this.alarmsList.Name = "alarmsList";
            this.alarmsList.Size = new System.Drawing.Size(328, 199);
            this.alarmsList.TabIndex = 0;
            this.alarmsList.SelectedIndexChanged += new System.EventHandler(this.alarmsList_SelectedIndexChanged);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 76);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(83, 32);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(257, 76);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(83, 32);
            this.removeButton.TabIndex = 2;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // statusText
            // 
            this.statusText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.statusText.Enabled = false;
            this.statusText.Location = new System.Drawing.Point(93, 340);
            this.statusText.Multiline = true;
            this.statusText.Name = "statusText";
            this.statusText.ReadOnly = true;
            this.statusText.Size = new System.Drawing.Size(171, 32);
            this.statusText.TabIndex = 3;
            this.statusText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // snoozeButton
            // 
            this.snoozeButton.Enabled = false;
            this.snoozeButton.Location = new System.Drawing.Point(12, 409);
            this.snoozeButton.Name = "snoozeButton";
            this.snoozeButton.Size = new System.Drawing.Size(75, 23);
            this.snoozeButton.TabIndex = 4;
            this.snoozeButton.Text = "Snooze";
            this.snoozeButton.UseVisualStyleBackColor = true;
            this.snoozeButton.Click += new System.EventHandler(this.snoozeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(270, 409);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "STOP";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(135, 76);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 32);
            this.editButton.TabIndex = 6;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // currentAlarmStatus
            // 
            this.currentAlarmStatus.Enabled = false;
            this.currentAlarmStatus.Location = new System.Drawing.Point(93, 411);
            this.currentAlarmStatus.Name = "currentAlarmStatus";
            this.currentAlarmStatus.Size = new System.Drawing.Size(171, 20);
            this.currentAlarmStatus.TabIndex = 7;
            this.currentAlarmStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentAlarmStatus.TextChanged += new System.EventHandler(this.currentAlarmStatus_TextChanged);
            // 
            // alarmGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(352, 444);
            this.Controls.Add(this.currentAlarmStatus);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.snoozeButton);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.alarmsList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "alarmGUI";
            this.Text = "Alarm501";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox alarmsList;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox statusText;
        private System.Windows.Forms.Button snoozeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.TextBox currentAlarmStatus;
    }
}

