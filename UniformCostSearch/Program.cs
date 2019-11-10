using System;

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
        }
    }
}
