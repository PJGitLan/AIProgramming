using System;

namespace modelreflexlive
{

    abstract class Percept {

    }

    class LidarSensorInput : Percept {
        public double DistanceTo { get; set; }
    }

    abstract class Actuator {
        
    }

    class Brake : Actuator {
        public override string ToString() {
            return "BRAKE";
        }
    }

    class Nothing : Actuator {
        public override string ToString() {
            return "NOTHING";
        }
    }

    abstract class Agent {
        public abstract Actuator process(Percept p);
    }

    class SelfDrivingCar : Agent
    {
        private int currentTimestamp = 0;

        private double prevDistance;
        private double prevDistanceTimestamp;
        private bool hasState = false;

        public override Actuator process(Percept p) {
            currentTimestamp ++;
            Actuator action = new Nothing();

            if (p is LidarSensorInput) {
                LidarSensorInput lidarPerception = (LidarSensorInput) p;
                double currDistance = lidarPerception.DistanceTo;

                if (hasState) {
                    if (currDistance < prevDistance) {
                        double relativeVelocity = 
                            (prevDistance - currDistance) / (currentTimestamp - prevDistanceTimestamp);
                        double timeUntilCollision = currDistance / relativeVelocity;

                        if (timeUntilCollision < 5) {
                            action = new Brake();
                        }
                    }
                }

                // Update agent state with new input
                prevDistanceTimestamp = currentTimestamp;
                prevDistance = currDistance;
                hasState = true;
            }

            return action;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LidarSensorInput sensor = new LidarSensorInput();
            Agent agent = new SelfDrivingCar();

            sensor.DistanceTo = 10;
            Actuator action = agent.process(sensor);
            Console.WriteLine(action.ToString());

            sensor.DistanceTo = 15;
            action = agent.process(sensor);
            Console.WriteLine(action.ToString());

            sensor.DistanceTo = 13;
            action = agent.process(sensor);
            Console.WriteLine(action.ToString());

            sensor.DistanceTo = 10;
            action = agent.process(sensor);
            Console.WriteLine(action.ToString());
        }
    }
}
