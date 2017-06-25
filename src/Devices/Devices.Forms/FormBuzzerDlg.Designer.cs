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
            this.checkCanVol = new System.Windows.Forms.CheckBox();
            this.checkCanFreq = new System.Windows.Forms.CheckBox();
            this.groupState = new System.Windows.Forms.GroupBox();
            this.pictureState = new System.Windows.Forms.PictureBox();
            this.groupProperties.SuspendLayout();
            this.groupState.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureState)).BeginInit();
            this.SuspendLayout();
            // 
            // groupProperties
            // 
            this.groupProperties.Controls.Add(this.checkCanVol);
            this.groupProperties.Controls.Add(this.checkCanFreq);
            this.groupProperties.Location = new System.Drawing.Point(12, 12);
            this.groupProperties.Name = "groupProperties";
            this.groupProperties.Size = new System.Drawing.Size(432, 71);
            this.groupProperties.TabIndex = 0;
            this.groupProperties.TabStop = false;
            this.groupProperties.Text = "Properties";
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
            // groupState
            // 
            this.groupState.Controls.Add(this.pictureState);
            this.groupState.Location = new System.Drawing.Point(12, 90);
            this.groupState.Name = "groupState";
            this.groupState.Size = new System.Drawing.Size(269, 245);
            this.groupState.TabIndex = 1;
            this.groupState.TabStop = false;
            this.groupState.Text = "State";
            // 
            // pictureState
            // 
            this.pictureState.InitialImage = global::Devices.Forms.Properties.Resources.BuzzerOff;
            this.pictureState.Location = new System.Drawing.Point(7, 20);
            this.pictureState.Name = "pictureState";
            this.pictureState.Size = new System.Drawing.Size(253, 219);
            this.pictureState.TabIndex = 0;
            this.pictureState.TabStop = false;
            // 
            // FormBuzzerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 341);
            this.Controls.Add(this.groupState);
            this.Controls.Add(this.groupProperties);
            this.Name = "FormBuzzerDlg";
            this.Text = "Buzzer (Forms)";
            this.groupProperties.ResumeLayout(false);
            this.groupProperties.PerformLayout();
            this.groupState.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupProperties;
        private System.Windows.Forms.CheckBox checkCanVol;
        private System.Windows.Forms.CheckBox checkCanFreq;
        private System.Windows.Forms.GroupBox groupState;
        private System.Windows.Forms.PictureBox pictureState;
    }
}