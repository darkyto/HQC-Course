namespace Minesweeper
{
    using System;
    using System.Collections.Generic;

    internal class Engine
    {
        internal static void Start()
        {
            const int MOVES_TO_WIN = 35;
            string command = string.Empty;
            char[,] playfield = GeneratePlayfield();
            char[,] minefield = GenerateMinefield();
            int counter = 0;
            bool gameOver = false;
            List<Player> players = new List<Player>(6);
            int row = 0;
            int col = 0;
            bool showInstructions = true;
            bool gameWon = false;

            do
            {
                if (showInstructions)
                {
                    Console.WriteLine("Welcome to minesweeper game! See if you could get lucky and find all the fields without mines." +
                    " Command 'top' shows the top scorers, 'restart' begins new game, 'exit' exits the game!");
                    RenderField(playfield);
                    showInstructions = false;
                }

                Console.Write("Please enter row and column separated by space or command: ");
                command = Console.ReadLine().Trim();
                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                    int.TryParse(command[2].ToString(), out col) &&
                        row <= playfield.GetLength(0) && col <= playfield.GetLength(1))
                    {
                        command = "turn";
                    }
                }

                switch (command)
                {
                    case "top":
                        RenderRanklist(players);
                        break;
                    case "restart":
                        playfield = GeneratePlayfield();
                        minefield = GenerateMinefield();
                        RenderField(playfield);
                        gameOver = false;
                        showInstructions = false;
                        break;
                    case "exit":
                        Console.WriteLine("4a0, 4a0, 4a0!");
                        break;
                    case "turn":
                        if (minefield[row, col] != '*')
                        {
                            if (minefield[row, col] == '-')
                            {
                                MakeMove(playfield, minefield, row, col);
                                counter++;
                            }

                            if (MOVES_TO_WIN == counter)
                            {
                                gameWon = true;
                            }
                            else
                            {
                                RenderField(playfield);
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }

                        break;
                    default:
                        Console.WriteLine("\nError! Invalid command!\n");
                        break;
                }

                if (gameOver)
                {
                    RevealMinefield(minefield);
                    RenderField(minefield);
                    Console.Write(
                        "\nGame Over. Score: {0} points. " +
                        "Enter nick: ",
                        counter);
                    string nickname = Console.ReadLine();
                    Player player = new Player(nickname, counter);
                    if (players.Count < 5)
                    {
                        players.Add(player);
                    }
                    else
                    {
                        for (int i = 0; i < players.Count; i++)
                        {
                            if (players[i].Points < player.Points)
                            {
                                players.Insert(i, player);
                                players.RemoveAt(players.Count - 1);
                                break;
                            }
                        }
                    }

                    players.Sort((Player r1, Player r2) => r2.Name.CompareTo(r1.Name));
                    players.Sort((Player r1, Player r2) => r2.Points.CompareTo(r1.Points));
                    RenderRanklist(players);

                    playfield = GeneratePlayfield();
                    minefield = GenerateMinefield();
                    counter = 0;
                    gameOver = false;
                    showInstructions = true;
                }

                if (gameWon)
                {
                    Console.WriteLine("\nCongratulations! You discovered all the 35 safe cells.");
                    RenderField(minefield);
                    Console.WriteLine("Enter your nick: ");
                    string imeee = Console.ReadLine();
                    Player player = new Player(imeee, counter);
                    players.Add(player);
                    RenderRanklist(players);
                    playfield = GeneratePlayfield();
                    minefield = GenerateMinefield();
                    counter = 0;
                    gameWon = false;
                    showInstructions = true;
                }
            }
            while (command != "exit");
            Console.WriteLine("Thank you for playing!");
            Console.Read();
        }

        internal static void RenderRanklist(List<Player> players)
        {
            Console.WriteLine("\nRanklist:");
            if (players.Count > 0)
            {
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(
                        "{0}. {1} --> {2} boxes",
                        i + 1,
                        players[i].Name,
                        players[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Empty ranklist!\n");
            }
        }

        internal static void MakeMove(
            char[,] playfield,
            char[,] minefield,
            int row,
            int col)
        {
            char adjacentMinesCount = CountAdjacentMines(minefield, row, col);
            minefield[row, col] = adjacentMinesCount;
            playfield[row, col] = adjacentMinesCount;
        }

        internal static void RenderField(char[,] field)
        {
            int rowCount = field.GetLength(0);
            int colCount = field.GetLength(1);
            Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");
            for (int i = 0; i < rowCount; i++)
            {
                Console.Write("{0} | ", i);
                for (int j = 0; j < colCount; j++)
                {
                    Console.Write(string.Format("{0} ", field[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------\n");
        }

        internal static char[,] GeneratePlayfield()
        {
            int rowsCount = 5;
            int colsCOunt = 10;
            char[,] playfield = new char[rowsCount, colsCOunt];
            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCOunt; j++)
                {
                    playfield[i, j] = '?';
                }
            }

            return playfield;
        }

        internal static char[,] GenerateMinefield()
        {
            int rowsCount = 5;
            int colsCount = 10;
            char[,] mineField = new char[rowsCount, colsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                for (int j = 0; j < colsCount; j++)
                {
                    mineField[i, j] = '-';
                }
            }

            List<int> randomNumbersCollection = new List<int>();
            while (randomNumbersCollection.Count < 15)
            {
                Random random = new Random();
                int number = random.Next(50);
                if (!randomNumbersCollection.Contains(number))
                {
                    randomNumbersCollection.Add(number);
                }
            }

            foreach (int number in randomNumbersCollection)
            {
                int row = number / colsCount;
                int col = number % colsCount;
                if (col == 0 && number != 0)
                {
                    row--;
                    col = colsCount;
                }
                else
                {
                    col++;
                }

                mineField[row, col - 1] = '*';
            }

            return mineField;
        }

        internal static void RevealMinefield(char[,] minefield)
        {
            int row = minefield.GetLength(0);
            int col = minefield.GetLength(1);

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (minefield[i, j] != '*')
                    {
                        char minesCount = CountAdjacentMines(minefield, i, j);
                        minefield[i, j] = minesCount;
                    }
                }
            }
        }

        internal static char CountAdjacentMines(char[,] minefield, int row, int col)
        {
            int count = 0;
            int rows = minefield.GetLength(0);
            int cols = minefield.GetLength(1);

            if (row - 1 >= 0)
            {
                if (minefield[row - 1, col] == '*')
                {
                    count++;
                }
            }

            if (row + 1 < rows)
            {
                if (minefield[row + 1, col] == '*')
                {
                    count++;
                }
            }

            if (col - 1 >= 0)
            {
                if (minefield[row, col - 1] == '*')
                {
                    count++;
                }
            }

            if (col + 1 < cols)
            {
                if (minefield[row, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col - 1 >= 0))
            {
                if (minefield[row - 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row - 1 >= 0) && (col + 1 < cols))
            {
                if (minefield[row - 1, col + 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col - 1 >= 0))
            {
                if (minefield[row + 1, col - 1] == '*')
                {
                    count++;
                }
            }

            if ((row + 1 < rows) && (col + 1 < cols))
            {
                if (minefield[row + 1, col + 1] == '*')
                {
                    count++;
                }
            }

            return char.Parse(count.ToString());
        }
    }
}