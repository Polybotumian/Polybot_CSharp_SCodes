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
    public partial class FormSplashScreen : Form
    {
        public FormSplashScreen()
        {
            InitializeComponent();
        }

        // When FormSplashScreen loaded, this method, implements its code block
        private void FormSplashScreen_Load(object sender, EventArgs e)
        {
            // Initializes backgroundWorkerSplashScreen.RunWorkerAsync() for hiding FormSplashScreen
            backgroundWorkerSplashScreen.RunWorkerAsync();

            // Checks out if dirs.txt is exist or empty
            // If its not exist than loads FormLoad and it creates "dirs.txt" by StreamWriter writer object which is in FormLoad already
            // If its exist but empty, loads FormLoad and it will overwrite to dirs.txt
            // If its exist and ok, loads FormMain directly
            if (new FileInfo("dirs.txt").Exists == false)
            {
                FormLoad formLoad = new FormLoad();
                formLoad.Show();
            }
            else if (new FileInfo("dirs.txt").Length == 0)
            {
                FormLoad formLoad = new FormLoad();
                formLoad.Show();
            }
            else
            {
                FormMain formMain = new FormMain();
                formMain.Show();
            }
        }

        // Hides FormSplashScreen
        private void backgroundWorkerSplashScreen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) { Hide(); }
    }
}
