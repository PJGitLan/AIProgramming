using System;
using System.Collections.Generic;
using System.Text;

namespace GelinkteLijst
{
    class LinkedList
    {
        private Node firstNode = null;

        public LinkedList()
        {
            //Empty
        }

        public void Add(Node newNode)
        {
            if (firstNode != null)
            {
                Node node = firstNode;
                while (node.HasNext())
                {
                    node = node.NextNode;
                }

                node.NextNode = newNode;

            }
            else
            {
                firstNode = newNode;
            }
        }

        public void Remove()
        {

        }
    }
}
