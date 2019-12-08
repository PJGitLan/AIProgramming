using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MiniMaxAlgorithm
{
    class MiniMaxSearch
    {
        public Node MinimaxDecision(List<Node> possibleMoves)
        {
            return possibleMoves.OrderBy(possibleMoves => possibleMoves.Utility()).Last();
        }
    }
}
