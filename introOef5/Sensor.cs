using System;
using System.Collections.Generic;
using System.Text;

namespace introOef5
{
    class Sensor
    {
        // public int refreshRate { get; set; } = Convert.ToInt32(Console.ReadLine());

        private int refreshRate;

        public int RefreshRate
        {
            get { return refreshRate; }
            set 
            {
                Console.WriteLine("Set sensors refreshrate: ");
                refreshRate = Convert.ToInt32(Console.ReadLine());
            }
        }


        private float distanceIn;
        public float DistanceIn
        {
            get { return distanceIn; }
            set 
            { 
                distanceIn = updateDistance(); 
            }
        }

        public float updateDistance()
        {
            Console.WriteLine("Input Distance: ");
            float distanceIn = float.Parse(Console.ReadLine());
            return distanceIn;
        }
    }
}
