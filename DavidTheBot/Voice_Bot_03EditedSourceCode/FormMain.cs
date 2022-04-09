using System;// For basics
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;// For Process.Start
using System.Drawing;// Drawing and Imaging are for screenshot
using System.Drawing.Imaging;// Drawing and Imaging are for screenshot
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;// For app form
using System.Speech.Synthesis;// For speak
using System.Speech.Recognition;// For understand
using System.IO; // For reading .txt files

namespace Voice_Bot
{
    public partial class FormMain : Form
    {
        // These 2 are for David's both speech and speech recognition
        private SpeechSynthesizer speechSynthesizer = new SpeechSynthesizer();
        private SpeechRecognitionEngine speechRecognationEngine = new SpeechRecognitionEngine();
        
        // List of the embedded commands 
        private Choices _list = new Choices(new string[]{"open an app", "add a file","hey david", "hello", "how are you", "hi", "how you doing", "whats your name", 
            "whats up", "what time is it", "what date is it", "what is today", "what year is it", "close yourself", "open youtube",
            "open twitter", "open google", "add a file", "take screenshot"});
        
        // List of the user choice apps 
        private Choices _listUserApp = new Choices();
        
        // Grammar for main commands, this is the embedded ones
        private Grammar _grammar;
        
        // Grammar for user choice apps 
        private Grammar _userAppGrammar;
        
        // This one for "Hey David!" command. We just don't want him to hear everything while he is awake
        private bool _stateOfDavid;

        public FormMain()
        {
            // Instancing main command list to main command grammar. So David can understand user (he needs to match voices to text commands)
            _grammar = new Grammar(new GrammarBuilder(_list));
            try
            {
                speechRecognationEngine.RequestRecognizerUpdate();
                // Loading main voice commands to speech recognation engine
                speechRecognationEngine.LoadGrammar(_grammar);
                // When David hear something, he needs to do with that command. So we crate a method and adding it to his recognation engine. He sends what he heard to this method
                speechRecognationEngine.SpeechRecognized += SpeechRecognationEngineUserSpeechRecognized;
                speechRecognationEngine.SetInputToDefaultAudioDevice();
                // Setting up David's rec engine to be asynchronous. So he won't hear everything at once
                speechRecognationEngine.RecognizeAsync(RecognizeMode.Multiple);
            }
            catch { return; }
            // Selecting the David's gender, it's a he DUH
            speechSynthesizer.SelectVoiceByHints(VoiceGender.Male);
            // David salutes whoever opened opened him
            speechSynthesizer.SpeakAsync("hi, my name is david");
            // This one initialize everything on the design part
            InitializeComponent();
        }
        
        private void SpeechRecognationEngineUserSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            // This is what he understands and he assings it to userCommand
            string userCommand = e.Result.Text;
            
            // This one is shows user to which command he understood
            labelUserInputState.Text = e.Result.Text;
            
            // rnd for random answers from the text files which is in "davids" file (answer01.txt, answer02.txt)
            Random rnd = new Random();
            
            // Need to create string[] variables for answers. Of course we need same element number so it reads all file lines and assign line number as element number of string[]
            string[] answer01 = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer01.txt").Length];
            string[] answer02 = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer02.txt").Length];
            
            // Need to assign all answers to string[] variables
            answer01 = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer01.txt");
            answer02 = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\answer02.txt");
            
            // User needs to say "hey David" to david for making him hear other main commands. _stateOfDavid enables by saying "hey David" command
            if (userCommand == "hey david") { _stateOfDavid = true; labelCurentState.Text = "Listening"; labelCurentState.ForeColor = Color.Red; SayToUser("yes"); }
            
            // This is for another speech recognation action, but this line removes SpeechRecognationEngineForApp method so David doesn't send anything to that while he is at this code block
            speechRecognationEngine.SpeechRecognized -= SpeechRecognationEngineForApp;
            
            // Main command actions of David. He implements this block when _stateOfDavid is true on the other hands "hey David" command enables this code block
            if (_stateOfDavid)
            {
                switch (userCommand)
                {
                    case "hello":
                        AnswerToUser(answer01[rnd.Next(0, answer01.Length)]);
                        break;
                    case "hi":
                        AnswerToUser(answer01[rnd.Next(0, answer01.Length)]);
                        break;
                    case "whats your name":
                        AnswerToUser("my name is david");
                        break;
                    case "how are you":
                        AnswerToUser(answer02[rnd.Next(0, answer02.Length)]);
                        break;
                    case "how you doing":
                        AnswerToUser(answer02[rnd.Next(0, answer02.Length)]);
                        break;
                    case "whats up":
                        AnswerToUser(answer02[rnd.Next(0, answer02.Length)]);
                        break;
                    case "what time is it":
                        AnswerToUser("its " + DateTime.Now.ToString("h:mm tt"));
                        break;
                    case "what date is it":
                        AnswerToUser("its" + DateTime.Today.ToString("D"));
                        break;
                    case "what is today":
                        AnswerToUser("its" + DateTime.Today.DayOfWeek);
                        break;
                    case "what year is it":
                        AnswerToUser("its " + DateTime.Today.Year);
                        break;
                    case "open youtube":
                        AnswerToUser("opening youtube");
                        Process.Start("https://www.youtube.com");
                        break;
                    case "open twitter":
                        AnswerToUser("opening twitter");
                        Process.Start("https://twitter.com");
                        break;
                    case "open google":
                        AnswerToUser("opening google");
                        Process.Start("https://google.com");
                        break;
                    case "take screenshot":
                        AnswerToUser("taking screenshot");
                        TakeScreenshot();
                        break;
                    case "open an app":
                        try
                        {
                            // Unloads main commands so David won't understands main commands
                            speechRecognationEngine.UnloadGrammar(_grammar);
                            // List of the user selected application names
                            _listUserApp.Add(File.ReadAllLines(Directory.GetCurrentDirectory() + @"\davids\userApps.txt"));
                            // Instancing user app name list to user app grammar. So David can understand user selected app names
                            _userAppGrammar = new Grammar(new GrammarBuilder(_listUserApp));
                            speechRecognationEngine.RequestRecognizerUpdate();
                            // Loading user selected app names to speech recognation engine
                            speechRecognationEngine.LoadGrammar(_userAppGrammar);
                            // David sends what he heard to this method (this method for opening apps)
                            speechRecognationEngine.SpeechRecognized += SpeechRecognationEngineForApp;
                            speechRecognationEngine.SetInputToDefaultAudioDevice();
                            // Setting up David's rec engine to be synchronous. So he will hear everything at once
                            speechRecognationEngine.RecognizeAsync(RecognizeMode.Single);
                        }
                        catch { return; }
                        break;
                    case "add a file":
                        Add_A_File();
                        break;
                    case "close yourself":
                        speechSynthesizer.Speak("I'm closing myself, goodbye");
                        // Closes all forms/this program
                        Application.Exit();
                        break;
                }
            }
        }

        // For answering to user and stops taking commands except "hey David"
        public void AnswerToUser(string answer)
        {
            speechSynthesizer.SpeakAsync(answer);
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            // Need to make sure David doesn't hear anything unless it is "hey David"
            _stateOfDavid = false;
        }

        // This one not deactivates _stateOfDavid so he can still hears another commands
        public void SayToUser(string answer) { speechSynthesizer.SpeakAsync(answer); }

        // For user selected application name recognation
        private void SpeechRecognationEngineForApp(object sender, SpeechRecognizedEventArgs e)
        {
            string userApp = e.Result.Text;
            SayToUser("opening " + userApp);
            // Need to send application name to SearchPath method for running it
            SearchPath("\\" + userApp + ".exe");
            // Unloads user selected application grammar
            speechRecognationEngine.UnloadGrammar(_userAppGrammar);
            // Loads main command grammar
            speechRecognationEngine.LoadGrammar(_grammar);
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            _stateOfDavid = false;
        }

        private void Add_A_File()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            // Up left file dialog title
            fileDialog.Title = "Select the file you want";
            // Filter for file dialog so user can just select executable files
            fileDialog.Filter = "executable files (*.exe)|*.exe";
            DialogResult dialogResult = fileDialog.ShowDialog();
            // When user selects any file and clicks ok this code block will run
            if (dialogResult == DialogResult.OK)
            {
                string folder = Directory.GetCurrentDirectory() + @"\dirs.txt";
                // This line opens folder variable which is a path to a text file (dirs.txt) for all application files on the computer. It opens text file and adds selected file path to it
                // then adds a new line to it for an another file path
                File.AppendAllText(folder, fileDialog.FileName + Environment.NewLine);
                // Informs user about his/her file choice 
                AnswerToUser("the file has selected");
            }
            else
            {
                MessageBox.Show("There is no file selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                // Informs user about his/her file choice 
                AnswerToUser("the file has not selected");
            }
        }

        // For searching wanted application path from David's application memory which is dirs.txt
        private void SearchPath(string lookingFile)
        {
            try
            {
                // Opens dirs.txt file, counts all line numbers and add all line numbers as element count to string[] readText
                string[] readText = new string[File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dirs.txt").Length];
                // Opens dirs.txt file again and this thime adds all saved paths to readText string[] variable
                readText = File.ReadAllLines(Directory.GetCurrentDirectory() + @"\dirs.txt");
                // We need this one for if it finds more than one same name it runs first one and cancels searching
                bool findIt = false;
                for (int i = 0; i < readText.Length && findIt == false; i++)
                {
                    if (readText[i].Contains(lookingFile))
                    {
                        findIt = true;
                        Process.Start(readText[i]);
                    }
                }
                // If it can't find anything than this dialog informs user about it and asks him for an update to all path list which is in dirs.txt
                if (!findIt)
                {
                    DialogResult warningDialogResult;
                    warningDialogResult = MessageBox.Show("The file you wanted doesn't exist or David's file path list needs to be updated." +
                                                          "If you haven't specified the file path, you can do it by saying 'add a file' to David." +
                                                          " Do you want to update the whole file path list?", "Warning",
                                                          MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    // If user accepts update than the FormLoad will be loaded and unupdated FormMain will be closed. Than FormLoad code blocks starting to update dirs.txt
                    if (warningDialogResult == DialogResult.Yes)
                    {
                        FormLoad formLoad = new FormLoad();
                        this.Close();
                        formLoad.Show();
                    }
                }
            }
            catch { MessageBox.Show("There is an error accoured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }

        private void TakeScreenshot()
        {
            labelCurentState.Text = "Taking screenshot"; labelProcessTimeValue.ForeColor = Color.Yellow;
            // A chronometer for screenchot process, it starts at this point
            Stopwatch stopWatch = Stopwatch.StartNew();
            // random for screenshot serials so it won't overwrite to an another
            Random random = new Random();
            decimal picSerialNumber = random.Next();
            // This 3 lines of codes are for screenshot
            Bitmap bitMap = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(bitMap);
            graphics.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            // Saving screenshot by specified path and format of image
            bitMap.Save(Directory.GetCurrentDirectory() + $@"\Screenshots\{picSerialNumber}_davids_Screenshot" + @".jpg", ImageFormat.Jpeg);
            // Writes elapsed process time
            labelProcessTimeValue.Text = stopWatch.ElapsedMilliseconds + " milliseconds";
            labelCurentState.Text = "Waiting"; labelCurentState.ForeColor = Color.Green;
            // Resets chronometer
            stopWatch.Reset();
        }

        // This method adds a user selected .exe file path to dirs.exe. But its manuel and its in the menu strip, tools
        private void addAFileToolStripMenuItem_Click(object sender, EventArgs e) { Add_A_File(); }

        // This method also updates dirs.txt but its manuel. Its in the menu strip, tools
        private void updateFilePathListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLoad formLoad = new FormLoad();
            this.Close();
            formLoad.Show();
        }

        // This method for manuel adding user selected application names to userApps.txt
        private void addAnAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Getting and assigning userApps.txt file's path to folder variable
            string folder = Directory.GetCurrentDirectory() + @"\davids\userApps.txt";
            // If userApps.txt doesn't exist this block will create it immediately than runs other if block
            if (new FileInfo(folder).Exists == false) { File.CreateText(folder); }
            // If userApps.txt file exist than this block runs 
            if (new FileInfo(folder).Exists)
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                // Up left file dialog title
                fileDialog.Title = "Select the application you want";
                // Filter for file dialog so user can just select executable files
                fileDialog.Filter = "executable files (*.exe)|*.exe";
                DialogResult dialogResult = fileDialog.ShowDialog();
                // When user selects any file and clicks ok this code block will run
                if (dialogResult == DialogResult.OK)
                {
                    // Assigns selected file path to appPath
                    string appPath = fileDialog.FileName;
                    // This one is for removing chars just for once from appPath
                    bool stop = false;
                    // Removes every char but preserves "fileName.exe" part
                    for (int i = appPath.Length - 1; i > 0 && stop == false; i--)
                    {
                        // If it sees "\" char for the first time than it removes all chars between 0 index and "\" detected index 
                        if (appPath[i] == '\\')
                        {
                            // Implements above action
                            appPath = appPath.Remove(0, i + 1);
                            // True for stoping loop
                            stop = true;
                        }
                    }
                    // Removes ".exe" extension from "fileName.exe"
                    for (int i = appPath.Length - 1; i > 0 && stop == true; i--)
                    {
                        // If it sees "." char, it takes 0 index to i index and assigns it to appPath
                        if (appPath[i] == '.')
                        {
                            appPath = appPath.Remove(i);
                            // False for stoping loop
                            stop = false;
                        }
                    }
                    // Adds "fileName" to userApps.txt and adds a new line for an another
                    File.AppendAllText(folder, appPath + Environment.NewLine);
                    // Informs user about his selection
                    AnswerToUser("the application has selected");
                }
                else
                {
                    // Informs user about his selection
                    MessageBox.Show("There is no application selected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    AnswerToUser("the application has not selected");
                }
            }
        }
    }
}
