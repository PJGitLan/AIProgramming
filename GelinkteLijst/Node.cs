using System;
using System.Collections.Generic;
using System.Text;

namespace GelinkteLijst
{
    abstract class Node
    {
        //public int Position { get; set; }
        //public int PrevPosion { get; set; }
        public Node NextNode { get; set; }

        public bool HasNext() {
            return NextNode != null;
        }

        
    }
}
