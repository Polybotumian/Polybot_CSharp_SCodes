namespace MovieDb
{
    partial class FormMain
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
            this.labelMovieNameAdd = new System.Windows.Forms.Label();
            this.labelMovieCategoryAdd = new System.Windows.Forms.Label();
            this.textBoxMovieNameAdd = new System.Windows.Forms.TextBox();
            this.comboBoxMovieCategoriesAdd = new System.Windows.Forms.ComboBox();
            this.buttonMovieAdd = new System.Windows.Forms.Button();
            this.buttonMovieSearch = new System.Windows.Forms.Button();
            this.buttonWriteMovies = new System.Windows.Forms.Button();
            this.listBoxMovies = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // labelMovieNameAdd
            // 
            this.labelMovieNameAdd.AutoSize = true;
            this.labelMovieNameAdd.Location = new System.Drawing.Point(12, 9);
            this.labelMovieNameAdd.Name = "labelMovieNameAdd";
            this.labelMovieNameAdd.Size = new System.Drawing.Size(75, 15);
            this.labelMovieNameAdd.TabIndex = 0;
            this.labelMovieNameAdd.Text = "Movie Name";
            // 
            // labelMovieCategoryAdd
            // 
            this.labelMovieCategoryAdd.AutoSize = true;
            this.labelMovieCategoryAdd.Location = new System.Drawing.Point(12, 37);
            this.labelMovieCategoryAdd.Name = "labelMovieCategoryAdd";
            this.labelMovieCategoryAdd.Size = new System.Drawing.Size(91, 15);
            this.labelMovieCategoryAdd.TabIndex = 1;
            this.labelMovieCategoryAdd.Text = "Movie Category";
            // 
            // textBoxMovieNameAdd
            // 
            this.textBoxMovieNameAdd.Location = new System.Drawing.Point(126, 6);
            this.textBoxMovieNameAdd.Name = "textBoxMovieNameAdd";
            this.textBoxMovieNameAdd.Size = new System.Drawing.Size(203, 23);
            this.textBoxMovieNameAdd.TabIndex = 2;
            // 
            // comboBoxMovieCategoriesAdd
            // 
            this.comboBoxMovieCategoriesAdd.FormattingEnabled = true;
            this.comboBoxMovieCategoriesAdd.Items.AddRange(new object[] {
            "Action",
            "Comedy",
            "Drama",
            "Fantasy",
            "Horror",
            "Mystery",
            "Romance",
            "Thriller",
            "Western"});
            this.comboBoxMovieCategoriesAdd.Location = new System.Drawing.Point(126, 35);
            this.comboBoxMovieCategoriesAdd.Name = "comboBoxMovieCategoriesAdd";
            this.comboBoxMovieCategoriesAdd.Size = new System.Drawing.Size(203, 23);
            this.comboBoxMovieCategoriesAdd.Sorted = true;
            this.comboBoxMovieCategoriesAdd.TabIndex = 3;
            // 
            // buttonMovieAdd
            // 
            this.buttonMovieAdd.Location = new System.Drawing.Point(12, 64);
            this.buttonMovieAdd.Name = "buttonMovieAdd";
            this.buttonMovieAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonMovieAdd.TabIndex = 4;
            this.buttonMovieAdd.Text = "Add";
            this.buttonMovieAdd.UseVisualStyleBackColor = true;
            this.buttonMovieAdd.Click += new System.EventHandler(this.buttonMovieAdd_Click);
            // 
            // buttonMovieSearch
            // 
            this.buttonMovieSearch.Location = new System.Drawing.Point(133, 64);
            this.buttonMovieSearch.Name = "buttonMovieSearch";
            this.buttonMovieSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonMovieSearch.TabIndex = 7;
            this.buttonMovieSearch.Text = "Search";
            this.buttonMovieSearch.UseVisualStyleBackColor = true;
            this.buttonMovieSearch.Click += new System.EventHandler(this.buttonMovieSearch_Click);
            // 
            // buttonWriteMovies
            // 
            this.buttonWriteMovies.Location = new System.Drawing.Point(254, 64);
            this.buttonWriteMovies.Name = "buttonWriteMovies";
            this.buttonWriteMovies.Size = new System.Drawing.Size(75, 23);
            this.buttonWriteMovies.TabIndex = 11;
            this.buttonWriteMovies.Text = "Write";
            this.buttonWriteMovies.UseVisualStyleBackColor = true;
            this.buttonWriteMovies.Click += new System.EventHandler(this.buttonWriteMovies_Click);
            // 
            // listBoxMovies
            // 
            this.listBoxMovies.FormattingEnabled = true;
            this.listBoxMovies.ItemHeight = 15;
            this.listBoxMovies.Location = new System.Drawing.Point(12, 93);
            this.listBoxMovies.Name = "listBoxMovies";
            this.listBoxMovies.Size = new System.Drawing.Size(317, 124);
            this.listBoxMovies.TabIndex = 12;
            this.listBoxMovies.Click += new System.EventHandler(this.EditListItem_OnClick);
            this.listBoxMovies.DoubleClick += new System.EventHandler(this.EditListItem_OnDoubleClick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 232);
            this.Controls.Add(this.listBoxMovies);
            this.Controls.Add(this.buttonWriteMovies);
            this.Controls.Add(this.buttonMovieSearch);
            this.Controls.Add(this.buttonMovieAdd);
            this.Controls.Add(this.comboBoxMovieCategoriesAdd);
            this.Controls.Add(this.textBoxMovieNameAdd);
            this.Controls.Add(this.labelMovieCategoryAdd);
            this.Controls.Add(this.labelMovieNameAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MovideDb";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMovieNameAdd;
        private System.Windows.Forms.Label labelMovieCategoryAdd;
        private System.Windows.Forms.TextBox textBoxMovieNameAdd;
        private System.Windows.Forms.ComboBox comboBoxMovieCategoriesAdd;
        private System.Windows.Forms.Button buttonMovieAdd;
        private System.Windows.Forms.Button buttonMovieSearch;
        private System.Windows.Forms.Button buttonWriteMovies;
        private System.Windows.Forms.ListBox listBoxMovies;
    }
}
