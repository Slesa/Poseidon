namespace Devices.Forms
{
    partial class FormBuzzerDlg
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
            this.groupProperties = new System.Windows.Forms.GroupBox();
            this.checkCanFreq = new System.Windows.Forms.CheckBox();
            this.checkCanVol = new System.Windows.Forms.CheckBox();
            this.groupProperties.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupProperties
            // 
            this.groupProperties.Controls.Add(this.checkCanVol);
            this.groupProperties.Controls.Add(this.checkCanFreq);
            this.groupProperties.Location = new System.Drawing.Point(12, 12);
            this.groupProperties.Name = "groupProperties";
            this.groupProperties.Size = new System.Drawing.Size(200, 100);
            this.groupProperties.TabIndex = 0;
            this.groupProperties.TabStop = false;
            this.groupProperties.Text = "Properties";
            // 
            // checkCanFreq
            // 
            this.checkCanFreq.AutoSize = true;
            this.checkCanFreq.Location = new System.Drawing.Point(7, 20);
            this.checkCanFreq.Name = "checkCanFreq";
            this.checkCanFreq.Size = new System.Drawing.Size(103, 17);
            this.checkCanFreq.TabIndex = 0;
            this.checkCanFreq.Text = "Can &frequencies";
            this.checkCanFreq.UseVisualStyleBackColor = true;
            // 
            // checkCanVol
            // 
            this.checkCanVol.AutoSize = true;
            this.checkCanVol.Location = new System.Drawing.Point(7, 44);
            this.checkCanVol.Name = "checkCanVol";
            this.checkCanVol.Size = new System.Drawing.Size(82, 17);
            this.checkCanVol.TabIndex = 1;
            this.checkCanVol.Text = "Can &volume";
            this.checkCanVol.UseVisualStyleBackColor = true;
            // 
            // FormBuzzerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.groupProperties);
            this.Name = "FormBuzzerDlg";
            this.Text = "Buzzer (Forms)";
            this.groupProperties.ResumeLayout(false);
            this.groupProperties.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupProperties;
        private System.Windows.Forms.CheckBox checkCanVol;
        private System.Windows.Forms.CheckBox checkCanFreq;
    }
}