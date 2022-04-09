using System;//For basics
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;//For Process.Start
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;//For app form
using System.Speech.Synthesis;//For speak
using System.Speech.Recognition;//For understand
using System.IO; //For reading .txt files

namespace Voice_Bot
{
    public partial class FormMain : Form
    {
        private SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        private SpeechRecognitionEngine speechRecognation = new SpeechRecognitionEngine();
        private Choices _list = new Choices(new string[]{"open an app", "add a file","hey david", "hello", "how are you", "hi", "how you doing", "whats your name", "whats up", "what time is it",
           "what date is it", "what is today", "what year is it", "close yourself", "open youtube", "open twitter", "open google", "add a file", "take screenshot"});
        private Choices _listUserApp = new Choices();
        private Grammar grammar;
        private Grammar userAppGrammar;
        private bool _stateOfDavid;

        public FormMain()
        {
            //list.Add(File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\userApps.txt"));
            grammar = new Grammar(new GrammarBuilder(_list));
            try
            {
                speechRecognation.RequestRecognizerUpdate();
                speechRecognation.LoadGrammar(grammar);
                speechRecognation.SpeechRecognized += speechRecognation_UserSpeechRecognized;
                speechRecognation.SetInputToDefaultAudioDevice();
                speechRecognation.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }
            speechSynthesizer.SelectVoiceByHints(VoiceGender.Male);
            speechSynthesizer.SpeakAsync("hi, my name is david");
            InitializeComponent();
        }
        public void Say(string answer)
        {
            //labelCurentState.Text = "Speaking"; labelCurentState.ForeColor = Color.Orange;
            speechSynthesizer.SpeakAsync(answer);
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            _stateOfDavid = false;
        }
        public void SayAlitte(string answer) { speechSynthesizer.SpeakAsync(answer); }
        private void speechRecognation_UserSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string userCommand = e.Result.Text;
            labelUserInputState.Text = e.Result.Text;

            Random rnd = new Random();
            string[] answer01 = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer01.txt").Length];
            string[] answer02 = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer02.txt").Length];
            answer01 = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer01.txt");
            answer02 = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer02.txt");

            if (userCommand == "hey david") { _stateOfDavid = true; labelCurentState.Text = "Listening"; labelCurentState.ForeColor = Color.Red; SayAlitte("yes"); }
            speechRecognation.SpeechRecognized -= speechRecognation_ForApp;
            if (_stateOfDavid)
            {
                switch (userCommand)
                {
                    case "hello":
                        Say(answer01[rnd.Next(0, answer01.Length)]);
                        break;
                    case "hi":
                        Say(answer01[rnd.Next(0, answer01.Length)]);
                        break;
                    case "whats your name":
                        Say("my name is david");
                        break;
                    case "how are you":
                        Say(answer02[rnd.Next(0, answer02.Length)]);
                        break;
                    case "how you doing":
                        Say(answer02[rnd.Next(0, answer02.Length)]);
                        break;
                    case "whats up":
                        Say(answer02[rnd.Next(0, answer02.Length)]);
                        break;
                    case "what time is it":
                        Say("its " + DateTime.Now.ToString("h:mm tt"));
                        break;
                    case "what date is it":
                        Say("its" + DateTime.Today.ToString("D"));
                        break;
                    case "what is today":
                        Say("its" + DateTime.Today.DayOfWeek);
                        break;
                    case "what year is it":
                        Say("its " + DateTime.Today.Year);
                        break;
                    case "open youtube":
                        Say("opening youtube");
                        Process.Start("https://www.youtube.com");
                        break;
                    case "open twitter":
                        Say("opening twitter");
                        Process.Start("https://twitter.com");
                        break;
                    case "open google":
                        Say("opening google");
                        Process.Start("https://google.com");
                        break;
                    case "take screenshot":
                        Say("taking screenshot");
                        TakeScreenshot();
                        break;
                    case "open an app":
                        try
                        {
                            speechRecognation.UnloadGrammar(grammar);
                            _listUserApp.Add(File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\userApps.txt"));
                            userAppGrammar = new Grammar(new GrammarBuilder(_listUserApp));
                            speechRecognation.RequestRecognizerUpdate();
                            speechRecognation.LoadGrammar(userAppGrammar);
                            speechRecognation.SpeechRecognized += speechRecognation_ForApp;
                            speechRecognation.SetInputToDefaultAudioDevice();
                            speechRecognation.RecognizeAsync(RecognizeMode.Single);
                        }
                        catch { return; }
                        break;
                    case "add a file":
                        Add_A_File();
                        break;
                    case "close yourself":
                        speechSynthesizer.Speak("I'm closing myself, goodbye");
                        Application.Exit();
                        break;
                }
            }
        }
        private void speechRecognation_ForApp(object sender, SpeechRecognizedEventArgs e)
        {
            string userApp = e.Result.Text;
            SayAlitte("opening " + userApp);
            SearchPath("\\" + userApp + ".exe");
            speechRecognation.UnloadGrammar(userAppGrammar);
            speechRecognation.LoadGrammar(grammar);
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            _stateOfDavid = false;
        }
        private void Add_A_File()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Select the file you want";
            fileDialog.Filter = "executable files (*.exe)|*.exe";
            DialogResult dialogResult = fileDialog.ShowDialog();
            if (dialogResult == DialogResult.OK)
            {
                string folder = Directory.GetCurrentDirectory() + @"\dirs.txt";
                File.AppendAllText(folder, fileDialog.FileName + Environment.NewLine);
                Say("the file has selected");
            }
            else
            {
                MessageBox.Show("There is no file selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Say("the file has not selected");
            }
        }
        private void SearchPath(string lookingFile)
        {
            try
            {
                string[] readText = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dirs.txt").Length];
                readText = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dirs.txt");
                bool findIt = false;
                for (int i = 0; i < readText.Length && findIt == false; i++)
                {
                    if (readText[i].Contains(lookingFile))
                    {
                        findIt = true;
                        Process.Start(readText[i]);
                    }
                }
                if (!findIt)
                {
                    DialogResult warningDialogResult;
                    warningDialogResult = MessageBox.Show("The file you wanted doesn't exist or David's file path list needs to be updated." +
                                                          "If you haven't specified the file path, you can do it by saying 'add a file' to David." +
                                                          " Do you want to update the whole file path list?", "Warning",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (warningDialogResult == DialogResult.Yes)
                    {
                        FormLoad formLoad = new FormLoad();
                        this.Close();
                        formLoad.Show();
                    }
                }
            }
            catch
            {
                MessageBox.Show("There is an error accoured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TakeScreenshot()
        {
            labelCurentState.Text = "Taking screenshot"; labelProcessTimeValue.ForeColor = Color.Yellow;
            Stopwatch stopWatch = Stopwatch.StartNew();
            Random random = new Random();
            decimal picSerialNumber = random.Next();
            Bitmap bitMap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitMap);
            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            bitMap.Save(Directory.GetCurrentDirectory() + $@"\Screenshots\{picSerialNumber}_davids_Screenshot" + @".jpg", ImageFormat.Jpeg);
            //System.Threading.Thread.Sleep(1000);
            //File.Copy(Directory.GetCurrentDirectory() + $@"\Screenshots\{picSerialNumber}_davids_Screenshot" + @".jpg", Environment.GetFolderPath(Environment.SpecialFolder.Desktop),true);
            labelProcessTimeValue.Text = stopWatch.ElapsedMilliseconds + " milliseconds";
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            stopWatch.Reset();
        }
        private void addAFileToolStripMenuItem_Click(object sender, EventArgs e) { Add_A_File(); }
        private void updateFilePathListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad formLoad = new FormLoad();
            this.Close();
            formLoad.Show();
        }
        private void addAnAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string folder = Directory.GetCurrentDirectory() + @"\davids\userApps.txt";
            if (new FileInfo(folder).Exists == false)
            {
                File.CreateText(folder);
            }
            if (new FileInfo(folder).Exists)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Title = "Select the application you want";
                fileDialog.Filter = "executable files (*.exe)|*.exe";
                DialogResult dialogResult = fileDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string appPath = fileDialog.FileName;
                    bool stop = false;
                    for (int i = appPath.Length - 1; i > 0 && stop == false; i--)
                    {
                        if (appPath[i] == '\\')
                        {
                            appPath = appPath.Remove(0, i + 1);
                            stop = true;
                        }
                    }
                    for (int i = appPath.Length - 1; i > 0 && stop == true; i--)
                    {
                        if (appPath[i] == '.')
                        {
                            appPath = appPath.Remove(i);
                            stop = false;
                        }
                    }
                    File.AppendAllText(folder, appPath + Environment.NewLine);
                    Say("the application has selected");
                }
                else
                {
                    MessageBox.Show("There is no application selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Say("the application has not selected");
                }
            }
        }
    }
}
