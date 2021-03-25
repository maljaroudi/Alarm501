
namespace Alarm501
{
    partial class AdderRemover
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
            this.timeAddr1 = new Alarm501.TimeAddr();
            this.SuspendLayout();
            // 
            // timeAddr1
            // 
            this.timeAddr1.ConfirmAlarm = null;
            this.timeAddr1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.timeAddr1.Location = new System.Drawing.Point(0, 0);
            this.timeAddr1.Name = "timeAddr1";
            this.timeAddr1.Size = new System.Drawing.Size(424, 164);
            this.timeAddr1.TabIndex = 0;
            this.timeAddr1.Load += new System.EventHandler(this.timeAddr1_Load);
            // 
            // AdderRemover
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 164);
            this.Controls.Add(this.timeAddr1);
            this.Name = "AdderRemover";
            this.Text = "AdderRemover";
            this.Load += new System.EventHandler(this.AdderRemover_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private TimeAddr timeAddr1;
    }
}