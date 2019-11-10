using System;
using System.Collections.Generic;
using System.Text;

namespace UniformCostSearch
{
    class Problem
    {
        public Node InitialState { get; set; }
        public Node GoalState { get; set; }
        public bool GoalReached(Path path)
        {
            return path.Nodes.Contains(GoalState);
        }

    }
}
