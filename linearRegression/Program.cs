using System;
using System.Collections.Generic;

namespace linearRegression
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Point> Points = new List<Point>()
            {
                new Point(0.2f,4f),
                new Point(1f,5.3f),
                new Point(1.8f,4.7f),
                new Point(2.7f,6.2f),
                new Point(3.7f,5.5f),
                new Point(4.1f,7f),
                new Point(4.5f,6.2f),
                new Point(5.7f,5.9f),
                new Point(6.5f,7.1f),
                new Point(7.3f,7.7f),
                new Point(8,8)
            };
            Trendline trendline = new Trendline(Points);
            Predictor predictor = new Predictor();

            while (true)
            {
                Console.WriteLine("Choose an option");
                Console.WriteLine("1: Get X value");
                Console.WriteLine("2: Get Y value");
                Console.WriteLine("3: Exit");
                try
                {
                    int input = Convert.ToInt32(Console.ReadLine());                

                    if (input == 1)
                    {
                        Console.WriteLine("\nGeef een Y waarde: ");
                        float ans;
                        ans = float.Parse(Console.ReadLine());
                
                        Console.WriteLine("\nX: " + predictor.PredictX(ans, trendline) + "\n\n");
                        Console.ReadLine();
                    }

                    if (input == 2)
                    {
                        Console.WriteLine("\nGeef een X waarde: ");
                        float ans;
                        ans = float.Parse(Console.ReadLine());

                        Console.WriteLine("\nY: " + predictor.PredictY(ans, trendline) + "\n\n");
                        Console.ReadLine();
                    }

                    if (input == 3)
                    {
                        Environment.Exit(1);
                    }

                    else
                    {
                        Console.WriteLine("!!!Not an option\n");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("!!!Not a valid input\n");
                }
            }  
        }
    }
}
