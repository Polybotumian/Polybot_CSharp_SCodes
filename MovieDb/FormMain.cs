using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MovieDb.DataAccess.Context;
using MovieDb.DataAccess.Model;
using System.IO;

namespace MovieDb
{
    public partial class FormMain : Form
    {
        MovieContext movieContext = new MovieContext();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonMovieAdd_Click(object sender, EventArgs e)
        {
            if (textBoxMovieNameAdd.Text != string.Empty && comboBoxMovieCategoriesAdd.Text != string.Empty)
            {
                movieContext.Movies.Add(new MovieModel { Id = Guid.NewGuid(), Name = textBoxMovieNameAdd.Text, CreatedDate = DateTime.Now, Category = comboBoxMovieCategoriesAdd.Text });
                movieContext.SaveChanges();
            }
            else
            {
                MessageBox.Show("You haven't set movie name or category properly.", "Improper Configs", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonMovieSearch_Click(object sender, EventArgs e)
        {
            listBoxMovies.Items.Clear();

            if (textBoxMovieNameAdd.Text == string.Empty && textBoxMovieNameAdd.Text == string.Empty)
            {
                foreach (var movie in movieContext.Movies)
                {
                    listBoxMovies.Items.Add($"{movie.Name} | {movie.Category} | {movie.CreatedDate}");
                }
            }
            else if (textBoxMovieNameAdd.Text == string.Empty && textBoxMovieNameAdd.Text != string.Empty)
            {
                foreach (var movie in from movie in movieContext.Movies where movie.Category == comboBoxMovieCategoriesAdd.Text select movie)
                {
                    listBoxMovies.Items.Add($"{movie.Name} | {movie.Category} | {movie.CreatedDate}");
                }
            }
            else if (textBoxMovieNameAdd.Text != string.Empty && textBoxMovieNameAdd.Text == string.Empty)
            {
                foreach (var movie in from movie in movieContext.Movies where movie.Name == textBoxMovieNameAdd.Text select movie)
                {
                    listBoxMovies.Items.Add($"{movie.Name} | {movie.Category} | {movie.CreatedDate}");
                }
            }
            else if (textBoxMovieNameAdd.Text != string.Empty && textBoxMovieNameAdd.Text != string.Empty)
            {
                foreach (var movie in from movie in movieContext.Movies where movie.Name == textBoxMovieNameAdd.Text && movie.Category == comboBoxMovieCategoriesAdd.Text select movie)
                {
                    listBoxMovies.Items.Add($"{movie.Name} | {movie.Category} | {movie.CreatedDate}");
                }
            }
        }

        private void buttonWriteMovies_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.ShowDialog();
                DateTime id = DateTime.Now;

                using (FileStream fs = new FileStream(folderBrowserDialog.SelectedPath + $@"\MovieDb_{id.Day}{id.Month}{id.Year}_{id.Ticks}.txt", FileMode.OpenOrCreate, FileAccess.Write))
                {
                    using (StreamWriter sw = new StreamWriter(fs))
                    {
                        if (listBoxMovies.SelectedItems.Count == 0)
                        {
                            foreach (var result in listBoxMovies.Items)
                            {
                                sw.WriteLine(result);
                            }
                        }
                        else
                        {
                            foreach (var result in listBoxMovies.SelectedItems)
                            {
                                sw.WriteLine(result);
                            }
                        }
                    }
                }
            }
            listBoxMovies.Items.Clear();
            buttonMovieSearch_Click(sender, e);
        }

        private void EditListItem_OnDoubleClick(object sender, EventArgs e)
        {
            if (listBoxMovies.SelectedItem != null)
            {
                var arr = listBoxMovies.SelectedItem.ToString().Split('|');
                foreach (var item in from movie in movieContext.Movies where movie.Name.Contains(arr[0].ToString().Trim()) select movie)
                {
                    movieContext.Remove(item);
                }
                movieContext.SaveChanges();
                listBoxMovies.Items.Clear();
            }
        }

        private void EditListItem_OnClick(object sender, EventArgs e)
        {
            if (listBoxMovies.SelectedItem != null)
            {
                var arr = listBoxMovies.SelectedItem.ToString().Split('|');
                textBoxMovieNameAdd.Text = arr[0].Trim();
                comboBoxMovieCategoriesAdd.Text = arr[1].Trim();
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            movieContext.Dispose();
            listBoxMovies.Dispose();
        }
    }
}
