using System;
using System.Collections.Generic;
using System.Linq;

namespace minimax
{
    abstract class Node {

        public bool TurnPlayer1 { get; protected set; }

        public abstract List<Node> PossibleMoves();

        public float Utility() {
            if (TurnPlayer1) {
                return MaximinValue();
            } else {
                return MinimaxValue();
            }
        }

        public float MaximinValue() {
            if (TerminalTest()) {
                // NOTE: Why return -1 when it is the AI's turn?
                // If the turn is the AI's, it has not made its move yet. Yet it encounters a terminal state, which means the other player beat us and no decision can reverse this
                return TurnPlayer1 ? -1 : +1;
            } else if (GameFinishedWithoutWinner()) {
                return 0;
            } else {
                return PossibleMoves().Select(possibleMove => possibleMove.MinimaxValue()).Max();
            }
        }

        public float MinimaxValue() {
            if (TerminalTest()) {
                return TurnPlayer1 ? -1 : +1;
            } else if (GameFinishedWithoutWinner()) {
                return 0;
            } else {
                return PossibleMoves().Select(possibleMove => possibleMove.MaximinValue()).Min();
            }
        }

        public abstract bool TerminalTest();
        public abstract bool GameFinishedWithoutWinner();
        public List<Edge> Actions { get; }

        public Node() {
            Actions = new List<Edge>();
        }

        public void AddAction(Edge action) {
            Actions.Add(action);
        }

        public abstract void Log();

    }

    class Edge {
        public Node FromNode { get; }
        public Node ToNode { get; }

        public Edge(Node from, Node to) {
            FromNode = from;
            ToNode = to;
        }
    }

    class Problem {

        public Node InitialState { get; set; }

    }

    class TicTacToeBoard : Node {

        public const string EMPTY = " "; 
        public const string PLAYER1 = "X"; 

        public const string PLAYER2 = "O"; 

        public string[,] Board { get; }

        public TicTacToeBoard(string[,] initialBoard, bool turnPlayer1) {
            Board = initialBoard;
            TurnPlayer1 = turnPlayer1;
        }

        public override List<Node> PossibleMoves() {
            List<Node> possibleBoards = new List<Node>();
            for (int row = 0; row < 3; row ++) {
                for (int col = 0; col < 3; col ++) {
                    if (Board[row, col].Equals(EMPTY)) {
                        string[,] newBoard = Duplicate();
                        newBoard[row, col] = TurnPlayer1 ? PLAYER1 : PLAYER2;

                        possibleBoards.Add(new TicTacToeBoard(newBoard, !TurnPlayer1));
                    }
                }
            }

            return possibleBoards;
        }

        public string[,] Duplicate() {
            string[,] newGame = new string[3, 3];
            for (int row = 0; row < 3; row ++) {
                for (int col = 0; col < 3; col++) {
                    newGame[row, col] = Board[row,col];
                }
            }
            return newGame;
        }

        public override bool TerminalTest() {
            for (int row = 0; row < 3; row ++) {
                if (Board[row, 0] == Board[row, 1] && Board[row, 1] == Board[row, 2] && Board[row, 0] != EMPTY) {
                    return true;
                }
            }

            for (int col = 0; col < 3; col ++) {
                if (Board[0, col] == Board[1, col] && Board[1, col] == Board[2, col] && Board[0, col] != EMPTY) {
                    return true;
                }
            }

            if (Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2] && Board[0, 0] != EMPTY) {
                return true;
            }

            if (Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0] && Board[0, 2] != EMPTY) {
                return true;
            }

            return false;
        }

        public override bool GameFinishedWithoutWinner() {
            if (TerminalTest()) {
                return false; // There is winner
            }

            for (int row = 0; row < 3; row ++) {
                for (int col = 0; col < 3; col ++) {
                    if (Board[row, col] == EMPTY) {
                        return false; // Game not finished
                    }
                }
            }

            return true;
        }

        public override void Log() {
            Console.WriteLine("---");
            for (int row = 0; row < 3; row ++) {
                for (int col = 0; col < 3; col++) {
                    Console.Write(Board[row,col] + ",");
                }
                Console.WriteLine();
            }
            Console.WriteLine("---");
        }
    }

    class MinimaxSearch {
        public Node MinimaxDecision(List<Node> possibleMoves) {
            // Choose node with highest possible min value, because that choice will minimize chance of losing
            return possibleMoves.OrderBy(possibleMove => possibleMove.Utility()).Last();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            MinimaxSearch algorithm = new MinimaxSearch();

            /*
            string[,] initialBoard = new string[,] {
                { TicTacToeBoard.PLAYER2, TicTacToeBoard.PLAYER1, TicTacToeBoard.PLAYER2 },
                { TicTacToeBoard.PLAYER1, TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY },
                { TicTacToeBoard.PLAYER1, TicTacToeBoard.PLAYER2, TicTacToeBoard.EMPTY }
            };
            */
            string[,] initialBoard = new string[,] {
                { TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY },
                { TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY },
                { TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY, TicTacToeBoard.EMPTY }
            };

            // We assume the AI starts first and tries to maximize its value. This is actually maximin instead of minimax, but the gist is the same
            Node currState = new TicTacToeBoard(initialBoard, true);
            while (!currState.TerminalTest() && !currState.GameFinishedWithoutWinner()) {
                // Let AI make move
                currState = algorithm.MinimaxDecision(currState.PossibleMoves());

                // Wait for player input
                currState.Log();

                if (currState.TerminalTest() || currState.GameFinishedWithoutWinner()) {
                    break;
                }

                Console.WriteLine("Give row,column:");
                string input = Console.ReadLine();
                IEnumerable<int> rowCol = input.Split(",").Select(str => Convert.ToInt32(str));

                string[,] currBoardConfig = ((TicTacToeBoard) currState).Duplicate();
                currBoardConfig[rowCol.First(), rowCol.Last()] = TicTacToeBoard.PLAYER2;

                currState = new TicTacToeBoard(currBoardConfig, true);
                currState.Log();
            }

            Console.WriteLine("Game done");
        }
    }
}
