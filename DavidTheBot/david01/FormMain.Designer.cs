
namespace Voice_Bot
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.labelStateInfo = new System.Windows.Forms.Label();
            this.labelCurentState = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.labelProcessTimeHeader = new System.Windows.Forms.Label();
            this.labelProcessTimeValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelStateInfo
            // 
            resources.ApplyResources(this.labelStateInfo, "labelStateInfo");
            this.labelStateInfo.Name = "labelStateInfo";
            // 
            // labelCurentState
            // 
            this.labelCurentState.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.labelCurentState, "labelCurentState");
            this.labelCurentState.Name = "labelCurentState";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // labelProcessTimeHeader
            // 
            resources.ApplyResources(this.labelProcessTimeHeader, "labelProcessTimeHeader");
            this.labelProcessTimeHeader.Name = "labelProcessTimeHeader";
            // 
            // labelProcessTimeValue
            // 
            resources.ApplyResources(this.labelProcessTimeValue, "labelProcessTimeValue");
            this.labelProcessTimeValue.Name = "labelProcessTimeValue";
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.labelProcessTimeValue);
            this.Controls.Add(this.labelProcessTimeHeader);
            this.Controls.Add(this.labelStateInfo);
            this.Controls.Add(this.labelCurentState);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStateInfo;
        private System.Windows.Forms.Label labelCurentState;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelProcessTimeHeader;
        private System.Windows.Forms.Label labelProcessTimeValue;
    }
}

