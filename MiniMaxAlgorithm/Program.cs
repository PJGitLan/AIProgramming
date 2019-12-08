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
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY },
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY },
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY },
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY },
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY },
                {ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY, ConnectFourBoard.EMPTY }
            };

            Node currState = new ConnectFourBoard(initialBoard, true);
            while(!currState.TerminalTest() && !currState.GameDraw())
            {
                currState.Log();

                if(currState.TerminalTest() || currState.GameDraw())
                {
                    break;
                }

                bool done = false;
                string[,] currBoardConfig = ((ConnectFourBoard)currState).Duplicate();
                do
                {
                    Console.WriteLine("Give column:");
                    string input = Console.ReadLine();
                    int column = Convert.ToInt32(input);

                    for (int row = 5; row >= 0; row--)
                    {

                        if (currBoardConfig[row, column] == ConnectFourBoard.EMPTY && !done)
                        {
                            currBoardConfig[row, column] = ConnectFourBoard.PLAYER2;
                            done = true;
                            Console.WriteLine(row);
                        }

                        else if (row == 0 && !done)
                        {
                            Console.WriteLine("Can't place coin there");
                        }

                        
                    }
                } while (done);

                Console.WriteLine( "test" );

                currState = new ConnectFourBoard(currBoardConfig, true);
                currState.Log();
            }

            Console.WriteLine("Game done");
        }
    }
}
