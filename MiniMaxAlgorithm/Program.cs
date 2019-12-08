using System;
using System.Collections.Generic;
using System.Linq;

namespace MiniMaxAlgorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            MiniMaxSearch algorithm = new MiniMaxSearch();

            string[,] initialBoard = new string[,]
            {
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.PLAYER1 },
                {ConnectFourBoard.EMPTY, ConnectFourBoard.PLAYER2, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER2 },
                {ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2 },
                {ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1 },
                {ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2 },
                {ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER1, ConnectFourBoard.PLAYER2, ConnectFourBoard.PLAYER2 }
            };

            // We assume the AI starts first and tries to maximize its value. This is actually maximin instead of minimax, but the gist is the same
            Node currState = new ConnectFourBoard(initialBoard, true);
            while (!currState.TerminalTest() && !currState.GameDraw())
            {
                // Let AI make move
                currState = algorithm.MinimaxDecision(currState.PossibleMoves());

                // Wait for player input
                currState.Log();

                if (currState.TerminalTest() || currState.GameDraw())
                {
                    break;
                }

                Console.WriteLine("Give row,column:");
                string input = Console.ReadLine();
                IEnumerable<int> rowCol = input.Split(",").Select(str => Convert.ToInt32(str));

                string[,] currBoardConfig = ((ConnectFourBoard)currState).Duplicate();
                currBoardConfig[rowCol.First(), rowCol.Last()] = ConnectFourBoard.PLAYER2;

                currState = new ConnectFourBoard(currBoardConfig, true);
                currState.Log();
            }

            Console.WriteLine("Game done");
        }
    }
}
