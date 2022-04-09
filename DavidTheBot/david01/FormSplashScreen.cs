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

        private void FormSplashScreen_Load(object sender, EventArgs e)
        {
            backgroundWorkerSplashScreen.RunWorkerAsync();
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

        private void backgroundWorkerSplashScreen_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Hide();
        }
    }
}
