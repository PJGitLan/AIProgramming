using System;
using System.Collections.Generic;
using System.Text;

namespace UniformSearchFinal
{
    class Edge
    {
        public Node FromNode { get; }
        public Node ToNode { get; }
        public float Cost { get; }

        public Edge(Node from, Node to, float cost)
        {
            FromNode = from;
            ToNode = to;
            Cost = cost;
        }
    }
}
