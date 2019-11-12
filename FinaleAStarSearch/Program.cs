using System;
using System.Collections.Generic;
using System.IO;

namespace FinaleAStarSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                System.Console.WriteLine("Please enter an argument.");
                return;
            }
            Console.WriteLine(args[0]);

            SearchAlgorithm algorithm = new UniformSearch();

            string[] lines = File.ReadAllLines(args[0]);

            List<Node> Nodes = new List<Node>();

            for (int i = 2; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(':');
                string[] spaceSplit = splitted[0].Split(' ');
                float temp = float.Parse(spaceSplit[1]);
                Nodes.Add(new Node(new State(spaceSplit[0]), temp));
            }

            for (int i = 2; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(':');
                string[] spaceSplit = splitted[1].Split(' ');
                for (int j = 1; j < spaceSplit.Length; j += 2)
                {
                    foreach (Node n in Nodes)
                    {
                        if (n.State.Name == spaceSplit[j])
                        {
                            float temp = float.Parse(spaceSplit[j + 1]);
                            Nodes[i - 2].AddAction(new Edge(Nodes[i - 2], n, temp));
                        }
                    }
                }
            }



            Problem problem = new Problem();

            foreach (Node n in Nodes)
            {
                if (n.State.Name == lines[0])
                {
                    problem.InitialState = n;
                }
            }

            foreach (Node n in Nodes)
            {
                if (n.State.Name == lines[1])
                {
                    problem.GoalState = n;
                }
            }

            Path solution = algorithm.Search(problem);
            Console.WriteLine("Solution");
            solution.DebugLog();
        }
    }
}
