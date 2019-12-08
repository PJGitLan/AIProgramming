using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMaxAlgorithm
{
    class ConnectFourBoard : Node
    {
        public const string EMPTY = " ";
        public const string PLAYER1 = "X";
        public const string PLAYER2 = "O";

        public string[,] Board { get; }

        public ConnectFourBoard(string[,] initialBoard, bool turnPlayer1)
        {
            Board = initialBoard;
            TurnPlayer1 = turnPlayer1;
        }

        public override void Log()
        {
            Console.WriteLine("---------");
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    Console.Write(Board[row, col] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("----------");
        }

        public override List<Node> PossibleMoves()
        {
            List<Node> possibleBoards = new List<Node>();
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    if (Board[row, col].Equals(EMPTY) && (row+1 > 5 || Board[row+1, col].Equals(PLAYER2) || Board[row+1, col].Equals(PLAYER1)))
                    {
                        string[,] newBoard = Duplicate();
                        newBoard[row, col] = TurnPlayer1 ? PLAYER1 : PLAYER2;

                        possibleBoards.Add(new ConnectFourBoard(newBoard, !TurnPlayer1));
                    }
                }
            }
            return possibleBoards;

        }

        public string[,] Duplicate()
        {
            string[,] newGame = new string[6, 7];
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)
                {
                    newGame[row, col] = Board[row, col];
                }
            }
            return newGame;
        }

        public override bool TerminalTest() //Tester voor win
        {
            for (int row = 0; row < 6; row++)
            {
                for (int col = 0; col < 7; col++)//nog checken of elke positie bestaat
                {
                     if (col + 3 < 7 && Board[row, col] == Board[row, col + 1] && Board[row, col + 1] == Board[row, col + 2]
                        && Board[row, col + 2] == Board[row, col + 3] && Board[row, col] != EMPTY)
                    {
                        return true;
                    }

                    if (row + 3 < 6 && Board[row, col] == Board[row + 1, col] && Board[row + 1, col] == Board[row + 2, col]
                        && Board[row + 2, col] == Board[row + 3, col] && Board[row, col] != EMPTY)
                    {
                        return true;
                    }

                    if (row + 3 < 6 && col + 3 < 7 && Board[row, col] == Board[row + 1, col +1] && Board[row + 1, col + 1] == Board[row + 2, col + 2]
                        && Board[row + 2, col + 2] == Board[row + 3, col + 3] && Board[row, col] != EMPTY)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public override bool GameDraw()
        {
            if (TerminalTest())
            {
                return false; // There is winner
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (Board[row, col] == EMPTY)
                    {
                        return false; // Game not finished
                    }
                }
            }

            return true;
        }       
    }
}
