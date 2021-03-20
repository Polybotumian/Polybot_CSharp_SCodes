using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sanbetik
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("    __   ___\n   /  \\ |   \\©\n   \\__  |___/\n      \\ |   \\\n   \\__/ |___/\n\n");

            Console.Write("Welcome To Sanbetik!\r\nLoading.. ");

            Console.ForegroundColor = ConsoleColor.Yellow;

            for (int i = 1; i < 11; i++)
            {
                int crsr = Console.CursorTop;
                Console.CursorVisible = false;
                Console.Write("▄");
                Console.SetCursorPosition(i + 9, crsr);
                System.Threading.Thread.Sleep(500);
            }

            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                Console.Clear();
                Console.BackgroundColor = ConsoleColor.Red;

                Console.WriteLine("Press ESC to exit.\r\n");

                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine("Press the button for process.\r\n");
                Console.WriteLine("F1 = ADD/SUBSTRACT F2 = DIVIDE\r\nF3 = MULTIPLY        F4 = ");

                Console.BackgroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.White;

                ConsoleKeyInfo myKey = new ConsoleKeyInfo();

                //Console.WriteLine("Show the key... :");

                myKey = Console.ReadKey(true);

                // Console.WriteLine(myKey.Key);

                ishlemler ish1 = new ishlemler();

                switch (myKey.Key)
                {
                    case ConsoleKey.F1:
                        //Console.WriteLine("Case f1 : ADD/SUBSTRACT");
                        Console.Clear();
                        ish1.myAddSubstract();
                        break;

                    case ConsoleKey.F2:
                        //Console.WriteLine("Case f2 : DIVIDE");
                        Console.Clear();
                        ish1.myDivide();
                        break;

                    case ConsoleKey.F3:
                        //Console.WriteLine("Case f3 : MULTIPLY");
                        Console.Clear();
                        ish1.myMultiply();
                        break;

                    case ConsoleKey.F4:
                        //Console.WriteLine("Case f4 :         ");
                        Console.Clear();
                        //ish1.nameless();
                        break;
                }


                if (myKey.Key == ConsoleKey.Escape) { break; }
                else { }

            }

        }

    }

    class ishlemler
    {
        ConsoleKeyInfo proKey = new ConsoleKeyInfo();
        public void myAddSubstract()
        {
            while (true)
            {
                float myNum = 0f;
                int countNum;
                double sum;

                int y;

                while (true)
                {
                    try
                    {
                        sum = 0;

                        Console.WriteLine("Write your first integer and press ENTER,\r\nthen write your second integer and press ENTER.\r\n");

                        y = Console.CursorTop;

                        Console.CursorVisible = true;

                        myNum = Single.Parse(Console.ReadLine());

                        sum += myNum;

                        countNum = myNum.ToString().Length;

                        Console.SetCursorPosition(countNum + 1, y);

                        Console.Write("+ ");

                        countNum = Console.CursorLeft;

                        myNum = Single.Parse(Console.ReadLine());

                        sum += myNum;

                        countNum += myNum.ToString().Length;

                        Console.SetCursorPosition(countNum + 1, y);

                        Console.WriteLine($"= {sum}");

                        Console.CursorVisible = false;

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("\r\nPress ESC for get back to menu\r\n\tOR\t\t\t\r\nPress any button (except ESC) to continue.");

                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;

                        Console.WriteLine($"You must enter a number withing ({float.MinValue}) - ({float.MaxValue}).\r\n");

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;

                        System.Threading.Thread.Sleep(2000);

                        Console.WriteLine("Please rewrite.");

                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;

                        System.Threading.Thread.Sleep(1000);

                        Console.Clear();
                    }

                }


                proKey = Console.ReadKey();

                if (proKey.Key == ConsoleKey.Escape) { break; }
                else { Console.Clear(); }
            }
        }
        public void myDivide()
        {
            while (true)
            {
                float myNum = 1f;
                int countNum;
                double sum;

                int y;

                while (true)
                {
                    try
                    {
                        sum = 1;

                        Console.WriteLine("Write your first number and press ENTER,\r\nthen write your second integer and press ENTER.\r\n");

                        y = Console.CursorTop;

                        Console.CursorVisible = true;

                        myNum = Single.Parse(Console.ReadLine());

                        sum = myNum;

                        countNum = myNum.ToString().Length;

                        Console.SetCursorPosition(countNum + 1, y);

                        Console.Write("/ ");

                        countNum = Console.CursorLeft;

                        myNum = Single.Parse(Console.ReadLine());

                        sum /= myNum;

                        countNum += myNum.ToString().Length;

                        Console.SetCursorPosition(countNum + 1, y);

                        Console.WriteLine($"= {sum}");

                        Console.CursorVisible = false;

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("\r\nPress ESC for get back to menu\r\n\tOR\t\t\t\r\nPress any button (except ESC) to continue.");

                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;

                        Console.WriteLine($"You must enter an integer withing ({float.MinValue}) - ({float.MaxValue}).\r\n");

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;

                        System.Threading.Thread.Sleep(2000);

                        Console.WriteLine("Please rewrite.");

                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;

                        System.Threading.Thread.Sleep(1000);

                        Console.Clear();
                    }

                }

                proKey = Console.ReadKey();

                if (proKey.Key == ConsoleKey.Escape) { break; }
                else { Console.Clear(); }
            }
        }
        public void myMultiply()
        {
            while (true)
            {
                float myNum = 1f;
                int countNum;
                double sum;

                int y;

                while (true)
                {
                    try
                    {
                        sum = 1;

                        Console.WriteLine("Write your first number and press ENTER,\r\nthen write your second integer and press ENTER.\r\n");

                        y = Console.CursorTop;

                        Console.CursorVisible = true;

                        myNum = Single.Parse(Console.ReadLine());

                        sum = myNum;

                        countNum = myNum.ToString().Length;

                        Console.SetCursorPosition(countNum + 1, y);

                        Console.Write("* ");

                        countNum = Console.CursorLeft;

                        myNum = Single.Parse(Console.ReadLine());

                        sum *= myNum;

                        countNum += myNum.ToString().Length;

                        Console.SetCursorPosition(countNum + 1, y);

                        Console.WriteLine($"= {sum}");

                        Console.CursorVisible = false;

                        Console.ForegroundColor = ConsoleColor.DarkRed;

                        Console.WriteLine("\r\nPress ESC for get back to menu\r\n\tOR\t\t\t\r\nPress any button (except ESC) to continue.");

                        Console.ForegroundColor = ConsoleColor.White;

                        break;
                    }
                    catch
                    {
                        Console.BackgroundColor = ConsoleColor.Red;

                        Console.WriteLine($"You must enter an integer withing ({float.MinValue}) - ({float.MaxValue}).\r\n");

                        Console.BackgroundColor = ConsoleColor.Green;
                        Console.ForegroundColor = ConsoleColor.Black;

                        System.Threading.Thread.Sleep(2000);

                        Console.WriteLine("Please rewrite.");

                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;

                        System.Threading.Thread.Sleep(1000);

                        Console.Clear();
                    }

                }

                proKey = Console.ReadKey();

                if (proKey.Key == ConsoleKey.Escape) { break; }
                else { Console.Clear(); }
            }
        }
    }
}