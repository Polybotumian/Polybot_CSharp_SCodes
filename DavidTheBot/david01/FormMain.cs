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
        SpeechRecognitionEngine speechRecognation = new SpeechRecognitionEngine();
        private Choices list = new Choices(new string[]{"hey david", "hello", "how are you", "hi", "how you doing", "whats your name", "whats up", "what time is it", 
            "what date is it", "what is today", "what year is it", "close yourself", "open discord", "open youtube", "open twitter", "open steam", "open google", "take screenshot"});
        private bool _stateOfDavid;
        
        public FormMain()
        {
            //list.Add(new string[] {"hey david", "hello", "how are you", "hi", "how you doing", "whats your name", "whats up", "what time is it",
            //"what date is it", "what is today", "what year is it", "close yourself", "open discord", "open youtube", "open twitter", "open steam", "open google", "take screenshot"});
            //list.Add(File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\commandsKotias.txt"));
            Grammar grammar = new Grammar(new GrammarBuilder(list));

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
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
        public void Say(string answer)
        {
            speechSynthesizer.SpeakAsync(answer);
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            _stateOfDavid = false;
        }

        public void SayAlitte(string answer) { speechSynthesizer.SpeakAsync(answer); }

        private void speechRecognation_UserSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string userCommand = e.Result.Text;

            Random rnd = new Random();
            string[] answer01 = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer01.txt").Length];
            string[] answer02 = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer02.txt").Length];
            answer01 = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer01.txt");
            answer02 = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer02.txt");

            if (userCommand == "hey david") { _stateOfDavid = true; labelCurentState.Text = "Listening"; labelCurentState.ForeColor = Color.Red; SayAlitte("yes"); }

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
                    case "open discord":
                        Say("opening discord");
                        SearchPath("\\Discord.exe");
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
                    case "open steam":
                        Say("opening steam");
                        SearchPath("\\steam.exe");
                        break;
                    case "take screenshot":
                        Say("taking screenshot");
                        TakeScreenshot();
                        break;
                    case "close yourself":
                        speechSynthesizer.Speak("I'm closing myself, goodbye");
                        Application.Exit();
                        break;
                }
            }
        }
        private void SearchPath(string lookingFile)
        {
            string[] readText = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dirs.txt").Length];
            readText = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dirs.txt");

            for (int i = 0; i < readText.Length; i++)
            {
                if (readText[i].Contains(lookingFile))
                {
                    Process.Start(readText[i]);
                }
            }
        }
        private void TakeScreenshot()
        {
            labelCurentState.Text = "Taking screenshot"; labelProcessTimeValue.ForeColor = Color.Yellow;
            //Stopwatch stopWatch = Stopwatch.StartNew();
            Random random = new Random();
            decimal picSerialNumber = random.Next();
            Bitmap bitMap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitMap);
            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            bitMap.Save(Directory.GetCurrentDirectory() + $@"\Screenshots\{picSerialNumber}_davids_Screenshot" + @".jpg", ImageFormat.Jpeg);
            //labelProcessTimeValue.Text = stopWatch.ElapsedMilliseconds + " milliseconds";
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            //stopWatch.Reset();
        }
    }
}
