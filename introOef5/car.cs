using System;
using System.Collections.Generic;
using System.Text;

namespace introOef5
{
    class Car
    {
        
        public Car()
        {
            Sensor sensor = new Sensor();
            Distance = sensor.DistanceIn;
        }

        public float Distance { get; set; }
        public float PrevDistance { get; set; }
        public float RelVelocity{ get; set; }
        public float CollisionTime { get; set; }
        public bool ValAvailable { get; set; } = false;

        private void Brake()
        {
            Console.WriteLine("Brake");
        }

        private void saveDistance()
        {
            PrevDistance = Distance;
            ValAvailable = true;
        }

        public void printStatus() {
            Console.WriteLine($"Distance = {Distance}");
            Console.WriteLine($"prevDistance = {PrevDistance}");
            Console.WriteLine($"RelVelocity = {RelVelocity}");
            Console.WriteLine($"CollisionTime = {CollisionTime}");
            Console.WriteLine($"ValAvailable = {ValAvailable}");
        }
    }
}
