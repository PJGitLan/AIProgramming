using System;
using System.Collections.Generic;
using System.IO;

namespace UniformCostSearch
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
                Nodes.Add(new Node(new State(splitted[0])));
            }

            for (int i = 2; i < lines.Length; i++)
            {
                string[] splitted = lines[i].Split(':');
                string[] spaceSplit = splitted[1].Split(' '); //mss 1ste spatie verwijderen? -->
                for (int j = 1; j < spaceSplit.Length; j+=2) //--> int j= 1
                {
                    foreach (Node n in Nodes)
                    {
                        if (n.State.Name == spaceSplit[j])
                        {
                            float temp = float.Parse(spaceSplit[j + 1]);
                            Nodes[i - 2].AddAction(new Edge(Nodes[i-2], n, temp));
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
