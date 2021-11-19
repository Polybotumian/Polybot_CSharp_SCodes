using System;

namespace KonsolDeneme
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] menuItems = { "Choose Alphabet", "Set Keyword", "Encrypt", "Decrypt" };
            short currentItem = 0;
            bool selected = false;
            bool isProgramRunning = true;

            Console.Title = "CRYPT-IT";

            Crypto kripto = new Crypto();

            while (isProgramRunning)
            {
                if (Console.KeyAvailable)
                {
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.UpArrow:
                            --currentItem;
                            if (currentItem < 0)
                            {
                                currentItem = (short)(menuItems.Length - 1);
                            }
                            else if (currentItem >= menuItems.Length)
                            {
                                currentItem = 0;
                            }
                            break;
                        case ConsoleKey.DownArrow:
                            ++currentItem;
                            if (currentItem < 0)
                            {
                                currentItem = (short)(menuItems.Length - 1);
                            }
                            else if (currentItem >= menuItems.Length)
                            {
                                currentItem = 0;
                            }
                            break;
                        case ConsoleKey.Enter:
                            selected = true;
                            break;
                        case ConsoleKey.Escape:
                            isProgramRunning = false;
                            break;
                    }
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nCRYPT-IT\n");
                Console.ForegroundColor = ConsoleColor.White;

                for (int i = 0; i < menuItems.Length; i++)
                {
                    if (i == currentItem)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("   >>");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(menuItems[i]);
                    }
                    else
                    {
                        Console.WriteLine(menuItems[i]);
                    }
                }

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n\nKeyword : {kripto._keyword}\nEncrypted Word : {kripto._encryptedString}\nDecrypted : {kripto._decryptedString}");
                Console.ForegroundColor = ConsoleColor.White;

                if (selected)
                {
                    switch (currentItem)
                    {
                        case 0:
                            string[] alphabetItems = { "Turkish", "English" };
                            bool isSubMenuOn = true;
                            bool subMenuSelected = false;
                            while (isSubMenuOn)
                            {
                                if (Console.KeyAvailable)
                                {
                                    switch (Console.ReadKey().Key)
                                    {
                                        case ConsoleKey.UpArrow:
                                            --currentItem;
                                            if (currentItem < 0)
                                            {
                                                currentItem = (short)(alphabetItems.Length - 1);
                                            }
                                            else if (currentItem >= alphabetItems.Length)
                                            {
                                                currentItem = 0;
                                            }
                                            break;
                                        case ConsoleKey.DownArrow:
                                            ++currentItem;
                                            if (currentItem < 0)
                                            {
                                                currentItem = (short)(alphabetItems.Length - 1);
                                            }
                                            else if (currentItem >= alphabetItems.Length)
                                            {
                                                currentItem = 0;
                                            }
                                            break;
                                        case ConsoleKey.Enter:
                                            subMenuSelected = true;
                                            break;
                                        case ConsoleKey.Escape:
                                            isSubMenuOn = false;
                                            break;
                                    }
                                }

                                for (int i = 0; i < alphabetItems.Length; i++)
                                {
                                    if (i == currentItem)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.Write("   >>");
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(alphabetItems[i]);
                                    }
                                    else
                                    {
                                        Console.WriteLine(alphabetItems[i]);
                                    }
                                }

                                if (subMenuSelected)
                                {
                                    kripto._selectedAlphabet = kripto._alphabets[currentItem];
                                    kripto._keyword = null;
                                    kripto._encryptedString = null;
                                    kripto._decryptedString = null;
                                    isSubMenuOn = false;
                                }
                                System.Threading.Thread.Sleep(50);
                                Console.Clear();
                            }
                            break;
                        case 1:
                            if (kripto._selectedAlphabet != null)
                            {
                                Console.Clear();
                                Console.Write("KEYWORD : ");
                                kripto.SetKeyword(Console.ReadLine());
                            }
                            else
                            {
                                Console.Beep();
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("\n\nYou haven't select any alphabet!\nPress any key to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                            if (kripto._keyword != null && kripto._selectedAlphabet != null)
                            {
                                kripto.CreateEncryptedAlphabet();
                            }
                            break;
                        case 2:
                            if (kripto._keyword != null)
                            {
                                Console.Clear();
                                Console.Write("String To Be Encrypted : ");
                                Console.WriteLine("\n\nYour encrypted string is \"" + kripto.Encrypt(Console.ReadLine()) + "\"\nPress any key to continue...");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Beep();
                                Console.WriteLine("\n\nYou haven't set a keyword.\nPress any key to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                            break;
                        case 3:
                            if (kripto._keyword != null)
                            {
                                Console.Clear();
                                Console.Write("String To Be Encrypted : ");
                                Console.WriteLine("\n\nYour encrypted string is \"" + (kripto.Decrypt(Console.ReadLine()) + "\"\nPress any key to continue..."));
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Beep();
                                Console.WriteLine("\n\nYou haven't set a keyword.\nPress any key to continue...");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.ReadKey();
                            }
                            break;
                    }
                    selected = false;
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n\t\t\t\tHOMEWORK OF YİĞİT LEBLEBİCİER\n\t\t\t\tNO : 2012721035" +
                                  "\n\t\t\t\tCOMPUTER ENGINEERING DEPARTMENT\n\t\t\t\tISUBÜ, 2021");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n\n\n\n\n\t\t\t\tUse arrow keys to navigate in menu.\n\t\t\t\tUse enter key to choose.\n\t\t\t\tUse ESC to exit." +
                                  "\n\t\t\t\tFirst choose an alphabet then set a keyword then you can use it.\n\t\t\t\tWhen you want to change settings you need to re-done the process.");

                System.Threading.Thread.Sleep(30);
                Console.Clear();
            }
        }
    }

    class Crypto
    {
        public string[] _alphabets = new string[]
        {
            "TR:abcçdefgğhıijklmnoöprsştuüvyz ", "ENG:abcdefghijklmnopqrstuvwxyz "
        };

        public string _selectedAlphabet = null;
        public string _selectedAlphabetTag = null;
        public string _keyword = null;
        public string _encryptedAlphabet = null;
        public string _encryptedString = null;
        public string _decryptedString = null;

        public Crypto()
        {
        }

        ~Crypto()
        {
        }

        public void SetKeyword(string keyword)
        {
            _keyword = null;
            int colonIndex = -1;

            for (int i = 0; i < _selectedAlphabet.Length; i++)
            {
                if (_selectedAlphabet[i] == ':')
                {
                    colonIndex = i;
                }
            }

            string cleanedAlphabet = null;
            string alphabetTag = null;

            for (int i = 0; i < _selectedAlphabet.Length; i++)
            {
                if (i > colonIndex)
                {
                    cleanedAlphabet += _selectedAlphabet[i];
                }
                else if (i < colonIndex)
                {
                    alphabetTag += _selectedAlphabet[i];
                }
            }

            _selectedAlphabet = cleanedAlphabet;
            _selectedAlphabetTag = alphabetTag;

            bool isKeywordSafe = false;

            for (int i = 0; i < keyword.Length; i++)
            {
                for (int j = 0; j < _selectedAlphabet.Length; j++)
                {
                    if (keyword[i] == _selectedAlphabet[j])
                    {
                        isKeywordSafe = true;
                    }
                }
            }

            for (int i = 0; i < keyword.Length; i++)
            {
                int count = 0;

                for (int j = 0; j < keyword.Length; j++)
                {
                    if (keyword[i] == keyword[j])
                    {
                        count++;
                    }
                }

                if (count > 1)
                {
                    isKeywordSafe = false;
                }
            }

            string tempNumberString = "0123456789";

            for (int i = 0; i < keyword.Length; i++)
            {
                for (int j = 0; j < tempNumberString.Length; j++)
                {
                    if (keyword[i] == tempNumberString[j])
                    {
                        isKeywordSafe = false;
                    }
                }
            }

            if (isKeywordSafe)
            {
                _keyword = keyword;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\n\nYour keyword cannot have any numbers and cannot contain repeating letters and unmatched chars to selected alphabet!\nPress any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }

        public void SetAlphabet(int index)
        {
            if (index >= 0 && index < _selectedAlphabet.Length)
            {
                _selectedAlphabet = _alphabets[index];
                _encryptedAlphabet = null;
            }
        }

        public string Encrypt(string word)
        {
            if (word != null)
            {
                word = word.ToLower();
                _encryptedString = null;

                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = 0; j < _selectedAlphabet.Length; j++)
                    {
                        if (word[i] == _selectedAlphabet[j])
                        {
                            _encryptedString += _encryptedAlphabet[j];
                        }
                    }
                }
            }

            return _encryptedString;
        }

        public void CreateEncryptedAlphabet()
        {
            _encryptedAlphabet = null;

            if (_keyword != null && _selectedAlphabet != null)
            {
                _encryptedAlphabet += _keyword;
                string tempString = null;
                bool isSafe = true;

                for (int j = 0; j < _selectedAlphabet.Length; j++)
                {
                    isSafe = true;

                    for (int k = 0; k < _keyword.Length && isSafe; k++)
                    {
                        if (_selectedAlphabet[j] == _keyword[k])
                        {
                            isSafe = false;
                        }
                    }

                    if (isSafe)
                    {
                        tempString += _selectedAlphabet[j];
                    }
                }

                _encryptedAlphabet += tempString;
            }
        }

        public string Decrypt(string word)
        {
            if (word != null && _encryptedAlphabet != null && _selectedAlphabet != null)
            {
                _decryptedString = null;

                for (int i = 0; i < word.Length; i++)
                {
                    for (int j = 0; j < _encryptedAlphabet.Length; j++)
                    {
                        if (word[i] == _encryptedAlphabet[j])
                        {
                            _decryptedString += _selectedAlphabet[j];
                        }
                    }
                }
            }

            return _decryptedString;
        }
    }
}
