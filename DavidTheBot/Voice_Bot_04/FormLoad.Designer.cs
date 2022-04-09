
namespace Voice_Bot
{
    partial class FormLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoad));
            this.backgroundWorkerLoadEvents = new System.ComponentModel.BackgroundWorker();
            this.progressBarFilesPaths = new System.Windows.Forms.ProgressBar();
            this.labelBarProgress = new System.Windows.Forms.Label();
            this.labelAboveProgressBar = new System.Windows.Forms.Label();
            this.buttonFormLoadCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backgroundWorkerLoadEvents
            // 
            this.backgroundWorkerLoadEvents.WorkerReportsProgress = true;
            this.backgroundWorkerLoadEvents.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerLoadEvents_DoWork);
            this.backgroundWorkerLoadEvents.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerLoadEvents_ProgressChanged);
            this.backgroundWorkerLoadEvents.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerLoadEvents_RunWorkerCompleted);
            // 
            // progressBarFilesPaths
            // 
            this.progressBarFilesPaths.Location = new System.Drawing.Point(12, 42);
            this.progressBarFilesPaths.Name = "progressBarFilesPaths";
            this.progressBarFilesPaths.Size = new System.Drawing.Size(187, 23);
            this.progressBarFilesPaths.TabIndex = 0;
            // 
            // labelBarProgress
            // 
            this.labelBarProgress.AutoSize = true;
            this.labelBarProgress.BackColor = System.Drawing.Color.Transparent;
            this.labelBarProgress.Location = new System.Drawing.Point(12, 68);
            this.labelBarProgress.Name = "labelBarProgress";
            this.labelBarProgress.Size = new System.Drawing.Size(21, 13);
            this.labelBarProgress.TabIndex = 1;
            this.labelBarProgress.Text = "0%";
            // 
            // labelAboveProgressBar
            // 
            this.labelAboveProgressBar.AutoSize = true;
            this.labelAboveProgressBar.Location = new System.Drawing.Point(9, 26);
            this.labelAboveProgressBar.Name = "labelAboveProgressBar";
            this.labelAboveProgressBar.Size = new System.Drawing.Size(190, 13);
            this.labelAboveProgressBar.TabIndex = 2;
            this.labelAboveProgressBar.Text = "Please wait, it\'s searhing for app paths.";
            // 
            // buttonFormLoadCancel
            // 
            this.buttonFormLoadCancel.Location = new System.Drawing.Point(124, 78);
            this.buttonFormLoadCancel.Name = "buttonFormLoadCancel";
            this.buttonFormLoadCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonFormLoadCancel.TabIndex = 3;
            this.buttonFormLoadCancel.Text = "Cancel";
            this.buttonFormLoadCancel.UseVisualStyleBackColor = true;
            this.buttonFormLoadCancel.Click += new System.EventHandler(this.buttonFormLoadCancel_Click);
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(211, 113);
            this.Controls.Add(this.buttonFormLoadCancel);
            this.Controls.Add(this.labelAboveProgressBar);
            this.Controls.Add(this.labelBarProgress);
            this.Controls.Add(this.progressBarFilesPaths);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "David The Bot";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormLoad_FormClosed);
            this.Shown += new System.EventHandler(this.FormLoad_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorkerLoadEvents;
        private System.Windows.Forms.ProgressBar progressBarFilesPaths;
        private System.Windows.Forms.Label labelBarProgress;
        private System.Windows.Forms.Label labelAboveProgressBar;
        private System.Windows.Forms.Button buttonFormLoadCancel;
    }
}