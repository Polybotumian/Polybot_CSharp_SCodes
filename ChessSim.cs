using System;
using System.Collections.Generic;

namespace kotias
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            menu.IsRunning = true;
            menu.MenuItems = new string[] {"Set Board Size", "Initialize Pawns", "Set Queen Position", "Draw Board", "Write All Validated Positions For The Queen" };
            menu.MenuHeadline = "CHESS-SIM";
            Console.Title = menu.MenuHeadline;
            menu.MenuCursor = ">>>";

            Board chessBoard = new Board();
            menu.CBoard = chessBoard;

            while (menu.IsRunning)
            {
                menu.MenuInput();
                menu.RenderMenu();
            }
        }
    }

    class Board
    {
        public Pawn[] Pawns;
        public Queen Queen;
        protected static UInt32[,] BoardMap;
        protected static UInt32 BoardSize;
        public UInt32 Size;

        public void SetBoardSize(UInt32 size)
        {
            if (size < 4)
            {
                size = 4;
            }
            else if (size > 8)
            {
                size = 8;
            }

            BoardSize = size;
            this.Size = BoardSize;
            BoardMap = new UInt32[BoardSize, BoardSize];
        }

        public void SetPawnsOnBoard()
        {
            for (UInt32 i = 0; i < Pawns.Length; i++)
            {
                for (UInt32 x = 0; x < BoardSize; x++)
                {
                    for (UInt32 y = 0; y < BoardSize; y++)
                    {
                        if (x == Pawns[i].PosX && y == Pawns[i].PosY)
                        {
                            BoardMap[y, x] = 1;
                        }
                    }
                }
            }
        }

        public void SetQueenOnBoard()
        {
            for (UInt32 x = 0; x < BoardSize; x++)
            {
                for (UInt32 y = 0; y < BoardSize; y++)
                {
                    if (x == Queen.PosX && y == Queen.PosY)
                    {
                        BoardMap[y, x] = 2;
                    }
                }
            }
        }

        public void RefreshBoardMap()
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    BoardMap[j, i] = 0;
                }
            }
        }

        public void WriteBoard()
        {
            for (UInt32 y = 0; y < BoardSize; y++)
            {
                for (UInt32 x = 0; x < BoardSize; x++)
                {
                    if (BoardMap[y, x] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    else if (BoardMap[y, x] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                    }
                    else if (BoardMap[y, x] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.Write(BoardMap[y, x]);
                }

                Console.WriteLine("");
            }

            Console.WriteLine("\n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        public virtual void WritePos()
        {
            Queen.WritePos();

            for (int i = 0; i < Pawns.Length; i++)
            {
                Pawns[i].WritePos();
            }
        }
    }

    class Pawn : Board
    {
        private UInt32 _posX;
        private UInt32 _posY;

        public UInt32 PosX
        {
            get { return _posX; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value >= BoardSize)
                {
                    value = BoardSize - 1;
                }

                _posX = value;
            }
        }

        public UInt32 PosY
        {
            get { return _posY; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value >= BoardSize)
                {
                    value = BoardSize - 1;
                }

                _posY = value;
            }
        }

        public override void WritePos()
        {
            Console.WriteLine("Pawn(X,Y) : " + _posX + ", " + _posY);
        }
    }

    class Queen : Board
    {
        private UInt32 _posX;
        private UInt32 _posY;
        public List<string> CanAttackThesePositions;

        int[] row = new[]    { 1, 1, 0, -1, -1, -1, 0, 1 };
        int[] column = new[] { 0, -1, -1, -1, 0, 1, 1, 1 };

        public UInt32 PosX
        {
            get { return _posX; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value >= BoardSize)
                {
                    value = BoardSize - 1;
                }

                _posX = value;
            }
        }

        public UInt32 PosY
        {
            get { return _posY; }
            set
            {
                if (value <= 0)
                {
                    value = 0;
                }
                else if (value >= BoardSize)
                {
                    value = BoardSize - 1;
                }

                _posY = value;
            }
        }

        public void CalculateAttackPositions()
        {
            CanAttackThesePositions = new List<string>();

            for (int i = 0; i < row.Length; i++)
            {
                int x = (int)PosX;
                int y = (int)PosY;

                while (true)
                {
                    x += row[i];
                    y += column[i];

                    if (x < 0 || x >= BoardSize || y < 0 || y >= BoardSize)
                    {
                        break;
                    }

                    if (BoardMap[y, x] == 1)
                    {
                        CanAttackThesePositions.Add("X: " + x + " Y: " + y + " ---> (Pawn On Square)");
                        break;
                    }

                    BoardMap[y, x] = 3;
                    CanAttackThesePositions.Add("X: " + x + " Y: " + y + " ---> (Empty Square)");
                }
            }
        }

        public override void WritePos()
        {
            Console.WriteLine("Queen(X,Y) : " + _posX + ", " + _posY);
        }
    }

    class Menu
    {
        public string[] MenuItems;
        public string MenuCursor = ">";
        public string MenuHeadline;
        public sbyte CurrentItem = 0;
        public bool SelectedItem;
        public bool IsRunning;
        public Board CBoard;

        public void RenderMenu()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(MenuHeadline + "\n");
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < MenuItems.Length; i++)
            {
                if (i == CurrentItem)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(MenuCursor);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine(MenuItems[i]);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\nHomework Of Yiğit Leblebicier, ISUBÜ 2021.\nUse Arrow Keys To Navigate In The Menu.\nUse Enter Key To Select An Option.");
            Console.ForegroundColor = ConsoleColor.White;

            System.Threading.Thread.Sleep(30);
            Console.Clear();
        }

        public void MenuInput()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        --CurrentItem;
                        if (CurrentItem < 0)
                        {
                            CurrentItem = (sbyte)(MenuItems.Length - 1);
                        }
                        else if (CurrentItem >= MenuItems.Length)
                        {
                            CurrentItem = 0;
                        }

                        break;
                    case ConsoleKey.DownArrow:
                        ++CurrentItem;
                        if (CurrentItem < 0)
                        {
                            CurrentItem = (sbyte)(MenuItems.Length - 1);
                        }
                        else if (CurrentItem >= MenuItems.Length)
                        {
                            CurrentItem = 0;
                        }

                        break;
                    case ConsoleKey.Enter:
                        SelectedItem = true;
                        break;
                    case ConsoleKey.Escape:
                        IsRunning = false;
                        break;
                }
            }

            if (SelectedItem)
            {
                Console.Clear();
                switch (CurrentItem)
                {
                    case 0:
                        Console.Write("Set your board size : ");
                        try
                        {
                            CBoard.SetBoardSize(Convert.ToUInt32(Console.ReadLine()));
                        }
                        catch
                        {
                            Console.WriteLine("Invalid value! Board size has set to 8 automatically.");
                            CBoard.SetBoardSize(8);
                            Console.ReadLine();
                        }
                        break;
                    case 1:
                        try
                        {
                            if (CBoard.Size >= 4)
                            {
                                Console.Write("Set For Pawn Count : ");
                                CBoard.Pawns = new Pawn[Convert.ToUInt32(Console.ReadLine())];
                                if (CBoard.Pawns.Length >= CBoard.Size * CBoard.Size)
                                {
                                    CBoard.Pawns = null;
                                    CBoard.Pawns = new Pawn[(CBoard.Size * CBoard.Size) - 1];
                                }
                                Console.WriteLine("Set Your Pawn Positions :");
                                for (int i = 0; i < CBoard.Pawns.Length; i++)
                                {
                                    CBoard.Pawns[i] = new Pawn();

                                    Console.WriteLine($"Pawn[{i}] (X, Y) : ");
                                    Console.Write("Position X : ");
                                    CBoard.Pawns[i].PosX = Convert.ToUInt32(Console.ReadLine());
                                    Console.Write("Position Y : ");
                                    CBoard.Pawns[i].PosY = Convert.ToUInt32(Console.ReadLine());
                                }
                            }
                            else
                            {
                                Console.WriteLine("You Haven't Set Board Size.");
                                Console.ReadKey();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid value format, type in a valid format.");
                            CBoard.Pawns = null;
                            Console.ReadLine();
                        }

                        break;
                    case 2:
                        try
                        {
                            if (CBoard.Size >= 4)
                            {
                                if (CBoard.Queen == null)
                                {
                                    CBoard.Queen = new Queen();
                                }
                                Console.WriteLine("Set Your Queen Position :");
                                Console.Write("Position X : ");
                                CBoard.Queen.PosX = Convert.ToUInt32(Console.ReadLine());
                                Console.Write("Position Y : ");
                                CBoard.Queen.PosY = Convert.ToUInt32(Console.ReadLine());
                            }
                            else
                            {
                                Console.WriteLine("You Haven't Set Board Size.");
                                Console.ReadKey();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Invalid value format, type in a valid format.");
                            Console.ReadLine();
                        }

                        break;
                    case 3:
                        if (CBoard.Size >= 4)
                        {
                            CBoard.RefreshBoardMap();

                            if (CBoard.Pawns != null)
                            {
                                CBoard.SetPawnsOnBoard();
                            }

                            if (CBoard.Queen != null)
                            {
                                CBoard.SetQueenOnBoard();
                                CBoard.Queen.CalculateAttackPositions();
                            }
                        }
                        else
                        {
                            Console.WriteLine("You Haven't Set Board Size.");
                        }

                        CBoard.WriteBoard();
                        Console.ReadKey();
                        break;
                    case 4:
                        if (CBoard.Size >= 4)
                        {
                            CBoard.RefreshBoardMap();

                            if (CBoard.Pawns != null)
                            {
                                CBoard.SetPawnsOnBoard();
                            }

                            if (CBoard.Queen != null)
                            {
                                CBoard.SetQueenOnBoard();
                                CBoard.Queen.CalculateAttackPositions();
                                CBoard.Queen.CanAttackThesePositions.Sort();

                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("Queen Can Move To These Positions :");
                                Console.ForegroundColor = ConsoleColor.White;

                                foreach (var position in CBoard.Queen.CanAttackThesePositions)
                                {
                                    Console.WriteLine(position);
                                }
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.WriteLine("You Haven't Set An Queen");
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You Haven't Set Board Size.");
                        }

                        Console.ReadKey();
                        break;
                }
                SelectedItem = false;
            }
        }
    }
}
