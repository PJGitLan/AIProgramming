using System;
using System.Collections.Generic;
using System.Text;

namespace UniformCostSearch
{
    class Frontier
    {
        public List<Path> Paths { get; }
        public Frontier(Problem problem)
        {
            Paths = new List<Path>();
            Paths.Add(new Path(problem.InitialState)); //waarschijnlijk fout
        }

        public Path NextPathToExplore()
        {
            int index = 0;
            //Path cheapestPath = new Path(Paths[index], Paths[index].LeafNode.Actions); //kan maar 1 actie doorgeven
            Path cheapestPath = Paths[index]; //Path kopieren?
            int indexToRemove = index;
            
            foreach(Path p in Paths){
                //Console.WriteLine(p.Cost);
                //Console.WriteLine(cheapestPath.Cost);
                if (p.Cost < cheapestPath.Cost)
                {
                    cheapestPath = p;
                    indexToRemove = index;
                    //Console.WriteLine(p.Cost);
                }
                index++;
            }
            Console.WriteLine("--------------------------------------------");
            Paths.RemoveAt(indexToRemove); 
            return cheapestPath; 
        }
    }
}
