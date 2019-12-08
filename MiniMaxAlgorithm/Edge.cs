using System;
using System.Collections.Generic;
using System.Text;

namespace MiniMaxAlgorithm
{
    class Edge
    {
        public Node FromNode { get; }
        public Node ToNode { get; }

        public Edge(Node from, Node to) {
            FromNode = from;
            ToNode = to;
        }
    }
}
