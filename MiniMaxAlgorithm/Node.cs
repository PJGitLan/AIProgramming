using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMaxAlgorithm
{
    abstract class Node
    {
        public bool TurnPlayer1 { get; protected set; }

        public abstract List<Node> PossibleMoves();
       
        public List<Edge> Actions  {get; }


        public Node()
         {
            Actions = new List<Edge>();
         }

        public void addAction(Edge action)
        {
            Actions.Add(action);
        }

        public abstract bool TerminalTest();
        public abstract bool GameDraw();

        public abstract void Log();

        public float MaximinValue()
        {
            if (TerminalTest())
            {
                // NOTE: Why return -1 when it is the AI's turn?
                // If the turn is the AI's, it has not made its move yet. Yet it encounters a terminal state, which means the other player beat us and no decision can reverse this
                return TurnPlayer1 ? -1 : +1;
            }
            else if (GameDraw())
            {
                return 0;
            }
            else
            {
                return PossibleMoves().Select(possibleMove => possibleMove.MinimaxValue()).Max();
            }
        }

        public float MinimaxValue()
        {
            if (TerminalTest())
            {
                return TurnPlayer1 ? -1 : +1;
            }
            else if (GameDraw())
            {
                return 0;
            }
            else
            {
                return PossibleMoves().Select(possibleMove => possibleMove.MaximinValue()).Min();
            }
        }

        public float Utility()
        {
            if (TurnPlayer1)
            {
                return MaximinValue();
            }
            else
            {
                return MinimaxValue();
            }
        }
    }
}
