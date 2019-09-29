using System;
using System.Collections.Generic;
using System.Text;

namespace introOef5
{
    class car
    {
        private float distance;

        public car(float _distance)
        {
            float distance = _distance;
        }
        public float PrevDistance { get; set; }
        public float RelVelocity{ get; set; }
        public float CollisionTime { get; set; }
        public bool ValAvailable { get; set; }

        private void Brake()
        {
            Console.WriteLine("Brake");
        }

        private void saveDistance()
        {
            PrevDistance = distance;
            ValAvailable = true;
        }
    }
}
