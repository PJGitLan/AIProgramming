using System;
using System.Collections.Generic;
using System.Text;

namespace UniformCostSearch
{
    abstract class SearchAlgorithm
    {
        public abstract Path Search(Problem problem);
        
    }

    class UniformSearch : SearchAlgorithm
    {
        public override Path Search(Problem problem)
        {
            Frontier frontier = new Frontier(problem);
            List<Node> exploredItems = new List<Node>();

            while (true)
            {
                if(frontier.Paths.Count == 0)
                {
                    return null; //geen resultaat
                }

                Path pathToExplore = frontier.NextPathToExplore();
                exploredItems.Add(pathToExplore.LeafNode);

                foreach(Edge action in pathToExplore.LeafNode.Actions)
                {
                    Node childnode = action.ToNode;
                    
                    Path pathAfterFollowingAction = new Path(pathToExplore, action);
                    pathAfterFollowingAction.DebugLog();

                    if (problem.GoalReached(pathAfterFollowingAction))
                    {
                        return pathAfterFollowingAction;
                    }
                    else
                    {
                        frontier.Paths.Add(pathAfterFollowingAction);
                    }
                }


            }
        }
    }
}
