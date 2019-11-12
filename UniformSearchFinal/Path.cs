using System;
using System.Collections.Generic;
using System.Text;

namespace UniformSearchFinal
{
    class Path
    {
        public List<Node> Nodes { get; }

        public Node LeafNode { get; }
        public float Cost { get; }
        public float heuristicValue { get; }

        public Path(Node initialState)
        {
            Nodes = new List<Node>();
            Nodes.Add(initialState);

            LeafNode = initialState;

            Cost = 0;
        }

        public Path(Path currPath, Edge actionToFollow)
        {
            Nodes = new List<Node>(currPath.Nodes);
            Nodes.Add(actionToFollow.ToNode);

            LeafNode = actionToFollow.ToNode;
            Cost = currPath.Cost + actionToFollow.Cost;
        }

        public void DebugLog()
        {
            foreach(Node n in Nodes)
            {
                Console.Write(n.State.Name + " -->");
            }
            Console.WriteLine();
        }
    }
}
    