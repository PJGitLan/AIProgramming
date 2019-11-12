using System;
using System.Collections.Generic;
using System.Text;

namespace FinaleAStarSearch
{
    class Node
    {
        public State State { get; }
        public List<Edge> Actions { get;  }
        public float HeuristicValue { get; }

        public Node(State state, float heuristicValue)
        {
            State = state;
            Actions = new List<Edge>();
            HeuristicValue = heuristicValue;
        }

        public void AddAction(Edge action)
        {
            Actions.Add(action);
        }
    }
}
