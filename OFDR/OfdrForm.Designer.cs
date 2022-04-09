namespace OFDR
{
    partial class OfdrForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OfdrForm));
            this.btnOFSelect = new System.Windows.Forms.Button();
            this.pathBoxOF = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnAFSelect = new System.Windows.Forms.Button();
            this.pathBoxAF = new System.Windows.Forms.TextBox();
            this.btnWork = new System.Windows.Forms.Button();
            this.richTextBoxPreview = new System.Windows.Forms.RichTextBox();
            this.labelPreview = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOFSelect
            // 
            this.btnOFSelect.Location = new System.Drawing.Point(12, 13);
            this.btnOFSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnOFSelect.Name = "btnOFSelect";
            this.btnOFSelect.Size = new System.Drawing.Size(86, 31);
            this.btnOFSelect.TabIndex = 0;
            this.btnOFSelect.Text = "Select";
            this.btnOFSelect.UseVisualStyleBackColor = true;
            this.btnOFSelect.Click += new System.EventHandler(this.BtnSelectOF);
            // 
            // pathBoxOF
            // 
            this.pathBoxOF.Location = new System.Drawing.Point(104, 15);
            this.pathBoxOF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathBoxOF.Name = "pathBoxOF";
            this.pathBoxOF.PlaceholderText = "Optic Form";
            this.pathBoxOF.ReadOnly = true;
            this.pathBoxOF.Size = new System.Drawing.Size(227, 27);
            this.pathBoxOF.TabIndex = 1;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Text Files (any.txt)|*.txt";
            this.openFileDialog.InitialDirectory = "C:\\Users\\Otlar\\OneDrive\\Masaüstü";
            // 
            // btnAFSelect
            // 
            this.btnAFSelect.Location = new System.Drawing.Point(12, 52);
            this.btnAFSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAFSelect.Name = "btnAFSelect";
            this.btnAFSelect.Size = new System.Drawing.Size(86, 31);
            this.btnAFSelect.TabIndex = 2;
            this.btnAFSelect.Text = "Select";
            this.btnAFSelect.UseVisualStyleBackColor = true;
            this.btnAFSelect.Click += new System.EventHandler(this.BtnSelectAF);
            // 
            // pathBoxAF
            // 
            this.pathBoxAF.Location = new System.Drawing.Point(104, 54);
            this.pathBoxAF.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pathBoxAF.Name = "pathBoxAF";
            this.pathBoxAF.PlaceholderText = "Answer Form";
            this.pathBoxAF.ReadOnly = true;
            this.pathBoxAF.Size = new System.Drawing.Size(227, 27);
            this.pathBoxAF.TabIndex = 3;
            // 
            // btnWork
            // 
            this.btnWork.Location = new System.Drawing.Point(124, 90);
            this.btnWork.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWork.Name = "btnWork";
            this.btnWork.Size = new System.Drawing.Size(86, 31);
            this.btnWork.TabIndex = 4;
            this.btnWork.Text = "Work";
            this.btnWork.UseVisualStyleBackColor = true;
            this.btnWork.Click += new System.EventHandler(this.BtnWork);
            // 
            // richTextBoxPreview
            // 
            this.richTextBoxPreview.Location = new System.Drawing.Point(12, 129);
            this.richTextBoxPreview.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.richTextBoxPreview.Name = "richTextBoxPreview";
            this.richTextBoxPreview.ReadOnly = true;
            this.richTextBoxPreview.Size = new System.Drawing.Size(319, 89);
            this.richTextBoxPreview.TabIndex = 5;
            this.richTextBoxPreview.Text = "";
            // 
            // labelPreview
            // 
            this.labelPreview.AutoSize = true;
            this.labelPreview.Location = new System.Drawing.Point(14, 101);
            this.labelPreview.Name = "labelPreview";
            this.labelPreview.Size = new System.Drawing.Size(67, 20);
            this.labelPreview.TabIndex = 6;
            this.labelPreview.Text = "Preview :";
            // 
            // OfdrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(343, 230);
            this.Controls.Add(this.labelPreview);
            this.Controls.Add(this.richTextBoxPreview);
            this.Controls.Add(this.btnWork);
            this.Controls.Add(this.pathBoxAF);
            this.Controls.Add(this.btnAFSelect);
            this.Controls.Add(this.pathBoxOF);
            this.Controls.Add(this.btnOFSelect);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(361, 277);
            this.MinimumSize = new System.Drawing.Size(361, 277);
            this.Name = "OfdrForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OFDR";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOFSelect;
        private System.Windows.Forms.TextBox pathBoxOF;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnAFSelect;
        private System.Windows.Forms.TextBox pathBoxAF;
        private System.Windows.Forms.Button btnWork;
        private System.Windows.Forms.RichTextBox richTextBoxPreview;
        private System.Windows.Forms.Label labelPreview;
    }
}
