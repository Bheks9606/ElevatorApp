using ElevatorApplication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class ElevatorPool
    {
        private Queue<Elevator> elevators;

        public ElevatorPool(int numberOfElevators, int startingFloor)
        {
            elevators = new Queue<Elevator>();
            for (int i = 0; i < numberOfElevators; i++)
            {
                elevators.Enqueue(new Elevator(startingFloor));
            }
        }

        public Elevator GetAvailableElevator(int currentFloor)
        {
            // Find the nearest available elevator
            Elevator nearestElevator = null;
            int minDistance = int.MaxValue;

            foreach (var elevator in elevators)
            {
                int distance = Math.Abs(currentFloor - elevator.CurrentFloor);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestElevator = elevator;
                }
            }

            return nearestElevator;
        }

        public void ReturnElevator(Elevator elevator)
        {
            // Reset elevator state when it returns to the pool
            elevator.DestinationFloor = elevator.CurrentFloor;
            elevator.Direction = Direction.Up;
            elevator.NumPeopleInside = 0;
            elevators.Enqueue(elevator);
        }

        public IEnumerable<Elevator> GetElevators()
        {
            return elevators;
        }
    }
}
