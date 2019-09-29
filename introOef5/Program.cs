using System;

namespace introOef5
{
    class Program
    {
        static void Main(string[] args)
        {
            int refreshRate = 1; //sensor
            bool valAvailable = false; //sensor
            float relVelocity = 0; //car
            float distance; //car 
            float prevDistance = 0; //car
            float collisionTime = 0; //car
            String distanceIn; //sensor

            while (true)
            {
                distanceIn = Console.ReadLine();
                distance = float.Parse(distanceIn);

                if (valAvailable == true)
                {
                    relVelocity = (prevDistance - distance) / (1 / refreshRate);
                    collisionTime = distance / relVelocity;

                    if (collisionTime < 5 && collisionTime > 0)
                    {
                        Console.WriteLine("\nBrake\n");
                    }
                }
                Console.WriteLine($"refreshRate = {refreshRate}");
                Console.WriteLine($"valAvailable = {valAvailable}");
                Console.WriteLine($"relVelocity = {relVelocity}");
                Console.WriteLine($"distance = {distance}");
                Console.WriteLine($"prevDistance = {prevDistance}");
                Console.WriteLine($"collisionTime = {collisionTime}");
                Console.WriteLine($"distanceIn = {distanceIn}");
                prevDistance = distance;
                valAvailable = true;
            }   
        }
    }
}
