using System;

namespace UniformCostSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            SearchAlgorithm algorithm = new UniformSearch();

            Node antwerpNode = new Node(new State("Antwerp"));
            Node hasseltNode = new Node(new State("Hasselt"));
            Node brusselNode = new Node(new State("Brussel"));
            Node charleroiNode = new Node(new State("Charleroi"));
            Node parijsNode = new Node(new State("Parijs"));
            Node kortijkNode = new Node(new State("Kortrijk"));
            Node gentNode = new Node(new State("Gent"));
            Node dePanneNode = new Node(new State("DePanne"));
            Node rotterdamNode = new Node(new State("Rotterdam"));

            antwerpNode.AddAction(new Edge(antwerpNode, gentNode, 9));
            antwerpNode.AddAction(new Edge(antwerpNode, rotterdamNode, 8));
            antwerpNode.AddAction(new Edge(antwerpNode, hasseltNode, 10));
            antwerpNode.AddAction(new Edge(antwerpNode, brusselNode, 7));

            gentNode.AddAction(new Edge(gentNode, antwerpNode, 9));
            gentNode.AddAction(new Edge(gentNode, dePanneNode, 12));
            gentNode.AddAction(new Edge(gentNode, kortijkNode, 5));
            gentNode.AddAction(new Edge(gentNode, brusselNode, 10));

            hasseltNode.AddAction(new Edge(hasseltNode, antwerpNode, 10));

            rotterdamNode.AddAction(new Edge(rotterdamNode, antwerpNode, 8));

            charleroiNode.AddAction(new Edge(charleroiNode, brusselNode, 6));

            brusselNode.AddAction(new Edge(brusselNode, antwerpNode, 7));
            brusselNode.AddAction(new Edge(brusselNode, gentNode, 10));
            brusselNode.AddAction(new Edge(brusselNode, charleroiNode, 6));

            kortijkNode.AddAction(new Edge(kortijkNode, gentNode, 5));
            kortijkNode.AddAction(new Edge(kortijkNode, parijsNode, 10));

            parijsNode.AddAction(new Edge(parijsNode, kortijkNode, 10));

            dePanneNode.AddAction(new Edge(dePanneNode, gentNode, 12));

            Problem problem = new Problem();
            problem.InitialState = antwerpNode;
            problem.GoalState = parijsNode;

            Path solution = algorithm.Search(problem);
            Console.WriteLine("Solution");
            solution.DebugLog();

        }
    }
}
