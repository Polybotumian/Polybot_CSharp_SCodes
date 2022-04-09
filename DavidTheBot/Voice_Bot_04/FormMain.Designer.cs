
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
            this.labelProcessTimeHeader = new System.Windows.Forms.Label();
            this.labelProcessTimeValue = new System.Windows.Forms.Label();
            this.labelUserInputState = new System.Windows.Forms.Label();
            this.labelUserInputHeader = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAnAppToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateFilePathListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.checkBoxSleepMode = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
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
            this.labelCurentState.BackColor = System.Drawing.Color.Transparent;
            this.labelCurentState.ForeColor = System.Drawing.Color.Green;
            resources.ApplyResources(this.labelCurentState, "labelCurentState");
            this.labelCurentState.Name = "labelCurentState";
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
            // labelUserInputState
            // 
            resources.ApplyResources(this.labelUserInputState, "labelUserInputState");
            this.labelUserInputState.Name = "labelUserInputState";
            // 
            // labelUserInputHeader
            // 
            resources.ApplyResources(this.labelUserInputHeader, "labelUserInputHeader");
            this.labelUserInputHeader.Name = "labelUserInputHeader";
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addAFileToolStripMenuItem,
            this.addAnAppToolStripMenuItem,
            this.updateFilePathListToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            resources.ApplyResources(this.toolsToolStripMenuItem, "toolsToolStripMenuItem");
            // 
            // addAFileToolStripMenuItem
            // 
            this.addAFileToolStripMenuItem.Name = "addAFileToolStripMenuItem";
            resources.ApplyResources(this.addAFileToolStripMenuItem, "addAFileToolStripMenuItem");
            this.addAFileToolStripMenuItem.Click += new System.EventHandler(this.addAFileToolStripMenuItem_Click);
            // 
            // addAnAppToolStripMenuItem
            // 
            this.addAnAppToolStripMenuItem.Name = "addAnAppToolStripMenuItem";
            resources.ApplyResources(this.addAnAppToolStripMenuItem, "addAnAppToolStripMenuItem");
            this.addAnAppToolStripMenuItem.Click += new System.EventHandler(this.addAnAppToolStripMenuItem_Click);
            // 
            // updateFilePathListToolStripMenuItem
            // 
            this.updateFilePathListToolStripMenuItem.Name = "updateFilePathListToolStripMenuItem";
            resources.ApplyResources(this.updateFilePathListToolStripMenuItem, "updateFilePathListToolStripMenuItem");
            this.updateFilePathListToolStripMenuItem.Click += new System.EventHandler(this.updateFilePathListToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.commandsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            resources.ApplyResources(this.commandsToolStripMenuItem, "commandsToolStripMenuItem");
            this.commandsToolStripMenuItem.Click += new System.EventHandler(this.commandsToolStripMenuItem_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // checkBoxSleepMode
            // 
            resources.ApplyResources(this.checkBoxSleepMode, "checkBoxSleepMode");
            this.checkBoxSleepMode.Name = "checkBoxSleepMode";
            this.checkBoxSleepMode.UseVisualStyleBackColor = true;
            this.checkBoxSleepMode.CheckedChanged += new System.EventHandler(this.checkBoxSleepMode_CheckedChanged);
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.Controls.Add(this.checkBoxSleepMode);
            this.Controls.Add(this.labelCurentState);
            this.Controls.Add(this.labelUserInputHeader);
            this.Controls.Add(this.labelUserInputState);
            this.Controls.Add(this.labelProcessTimeValue);
            this.Controls.Add(this.labelProcessTimeHeader);
            this.Controls.Add(this.labelStateInfo);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.TransparencyKey = System.Drawing.Color.LavenderBlush;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelStateInfo;
        private System.Windows.Forms.Label labelCurentState;
        private System.Windows.Forms.Label labelProcessTimeHeader;
        private System.Windows.Forms.Label labelProcessTimeValue;
        private System.Windows.Forms.Label labelUserInputState;
        private System.Windows.Forms.Label labelUserInputHeader;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addAnAppToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem commandsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateFilePathListToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.CheckBox checkBoxSleepMode;
    }
}

