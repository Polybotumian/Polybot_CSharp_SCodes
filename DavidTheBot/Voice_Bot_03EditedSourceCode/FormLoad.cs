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
        public FormLoad() { InitializeComponent(); }

        // When FormLoad shows itself this method runs and implements backgroundWorkerLoadEvents
        private void FormLoad_Shown(object sender, EventArgs e) { backgroundWorkerLoadEvents.RunWorkerAsync(); }

        // This one specifies what backgroundWorkerLoadEvents will do, it calls a method named SearchFiles
        private void backgroundWorkerLoadEvents_DoWork(object sender, DoWorkEventArgs e) { SearchFiles(); }

        // This method runs its code block whenever backgroundWorkerLoadEvents does something
        private void backgroundWorkerLoadEvents_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Changes progress bar visual for informing user
            progressBarFilesPaths.Value = e.ProgressPercentage;
            labelBarProgress.Text = progressBarFilesPaths.Value + "% compeleted";
        }

        // When backgroundWorkerLoadEvents fully completes its task this method runs
        private void backgroundWorkerLoadEvents_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Informs user by a message box
            MessageBox.Show("Searching is completed!", "Task is done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Initializes FormMain
            FormMain formMain = new FormMain();
            // Closes FormLoad
            this.Close();
            // Shows FormMain on the screen
            formMain.Show();
        }
        
        // This integer for progress bar
        private int _percentage;

        // By SearchFiles and GetFiles methods, it looks all hard drives // SSD's and writes all paths of executable files to dirs.txt
        // ATTENTION: SearchFiles and GetFiles methods are runs together and because of GetFiles is recursive, Windows inaccessible file paths doesn't disturps searching process
        public void SearchFiles()
        {
            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\dirs.txt");
            using (writer) //write to a file. This must be here to write lines more than once to the text file
            {
                // Gets all memory drive names on the computer and assign them to allDrivers
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                for (int i = 0; i < allDrives.Length; i++)
                {
                    // Recursively calls GetFiles method and send memory drive names as paths and all executable files as patterns 
                    // When the task is done it assigns all paths to files variable
                    List<string> files = GetFiles(allDrives[i].Name, "*.exe");

                    // Writes all elements of files variable as file variable to dirs.txt by using "writer" which is a StreamWriter object
                    foreach (var file in files)
                    {
                        writer.WriteLine(file);
                    }
                    // Calculates progress bar's percentage by using irrelevant way LOL
                    _percentage += allDrives.Length * 10;

                    // Well, this backgroundWorkerLoadEvents's ReportProgress does the trick and sends the _percentage to backgroundWorkerLoadEvents_ProgressChanged
                    // At least this what I think
                    backgroundWorkerLoadEvents.ReportProgress(_percentage);
                }
            }
            // Same progress here but this time it sends 100 number which is the limit for the progress bar so all task is done!
            // Whenever this code line does his task the backgroundWorkerLoadEvents_RunWorkerCompleted will run
            backgroundWorkerLoadEvents.ReportProgress(100);
        }

        // This is the recursive one
        private List<string> GetFiles(string path, string pattern)
        {
            var files = new List<string>();
            var directories = new string[] { };
            try
            {
                files.AddRange(Directory.GetFiles(path, pattern, SearchOption.TopDirectoryOnly));
                directories = Directory.GetDirectories(path);
            }
            catch (UnauthorizedAccessException) { }

            foreach (var directory in directories)
            {
                try
                {
                    files.AddRange(GetFiles(directory, pattern));
                }
                catch (UnauthorizedAccessException) {}
            }
            return files;
        }

        // Cancels searching path process and closes program by clicking cancel button
        private void buttonFormLoadCancel_Click(object sender, EventArgs e) { Application.Exit(); }
    }
}
