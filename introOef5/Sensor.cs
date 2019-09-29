using System;
using System.Collections.Generic;
using System.Text;

namespace introOef5
{
    class Sensor
    {
        public int refreshRate { get; set; } = 1;
        public bool valAvailable { get; set; } = false;

        private String distanceIn;
        public String DistanceIn
        {
            get { return distanceIn; }
            set { distanceIn = Console.ReadLine(); }
        }

    }
}
