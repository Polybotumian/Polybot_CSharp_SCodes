using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Voice_Bot
{
    public partial class FormLoad : Form
    {
        public FormLoad()
        {
            InitializeComponent();
        } 
        private void FormLoad_Shown(object sender, EventArgs e)
        {
            backgroundWorkerLoadEvents.RunWorkerAsync();
        }
        private void backgroundWorkerLoadEvents_DoWork(object sender, DoWorkEventArgs e)
        {
            if (new FileInfo("dirs.txt").Exists == false)
            {
                //FormLoad.SearchFiles();
                SearchFiles();
            }
            else if (new FileInfo("dirs.txt").Length == 0)
            {
                //FormLoad.SearchFiles();
                SearchFiles();
            }
        }
        private void backgroundWorkerLoadEvents_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBarFilesPaths.Value = e.ProgressPercentage;
            labelBarProgress.Text = progressBarFilesPaths.Value + "% compeleted";
        }
        private void backgroundWorkerLoadEvents_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("Searching is completed!", "Task is done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FormMain formMain = new FormMain();
            this.Close();
            formMain.Show();
        }
        public void SearchFiles()
        {
            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\dirs.txt");
            using (writer) //write to a file. This must be here to write lines more than once to the text file
            {
                string[] wantedFiles = { "discord", "steam" };
                DriveInfo[] allDrives = DriveInfo.GetDrives();
                for (int i = 0; i < allDrives.Length; i++)
                {
                    for (int j = 0; j < wantedFiles.Length; j++)
                    {
                        List<string> files = GetFiles(allDrives[i].Name, "*.exe");
                        foreach (var file in files)
                        {
                            writer.WriteLine(file);
                        }
                    }
                    percentage += allDrives.Length * 10;
                    backgroundWorkerLoadEvents.ReportProgress(percentage);
                }
            }
            //Read a file  
            //string readText = File.ReadAllText(Directory.GetCurrentDirectory() + @"\dirs.txt");
            //Console.WriteLine(readText);
            backgroundWorkerLoadEvents.ReportProgress(100);
        }

        private int percentage = 0;
        private List<string> GetFiles(string path, string pattern)
        {
            var files = new List<string>();
            var directories = new string[] { };
            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                directories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException) {}

            foreach (var directory in directories)
            {
                try
                {
                    files.AddRange(GetFiles(directory, pattern));
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
            return files;
        }
    }
}
