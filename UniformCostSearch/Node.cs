using System;
using System.Collections.Generic;
using System.Text;

namespace UniformCostSearch
{
    class Node
    {
        public State State { get; }
        public List<Edge> Actions { get;  }

        public Node(State state)
        {
            State = state;
            Actions = new List<Edge>();
        }

        public void AddAction(Edge action)
        {
            Actions.Add(action);
        }
    }
}
