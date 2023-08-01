using ElevatorApplication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Building
    {
        public int NumberOfFloors { get; }
        public List<Passenger> Passengers { get; }
        public List<int> PeopleWaitingOnFloors { get; }

        private ElevatorPool elevatorPool;

        public Building(int numberOfFloors, int numberOfElevators, int startingFloor)
        {
            NumberOfFloors = numberOfFloors;
            Passengers = new List<Passenger>();
            PeopleWaitingOnFloors = new List<int>();

            for (int i = 0; i < numberOfFloors; i++)
            {
                PeopleWaitingOnFloors.Add(0);
            }

            elevatorPool = new ElevatorPool(numberOfElevators, startingFloor);
        }

        public void AddPassenger(int currentFloor, int destinationFloor)
        {
            Passengers.Add(new Passenger(currentFloor, destinationFloor));
            PeopleWaitingOnFloors[currentFloor - 1]++;
        }

        public void CallElevator(int floor)
        {
            var elevator = elevatorPool.GetAvailableElevator(floor);
            if (elevator != null)
            {
                elevator.SetDestinationFloor(floor);
                MoveElevator(elevator);
            }
        }

        private void MoveElevator(Elevator elevator)
        {
            while (elevator.CurrentFloor != elevator.DestinationFloor)
            {
                if (elevator.Direction == Direction.Up && elevator.CurrentFloor < NumberOfFloors)
                {
                    elevator.MoveUp();
                }
                else if (elevator.Direction == Direction.Down && elevator.CurrentFloor > 1)
                {
                    elevator.MoveDown();
                }

                PrintElevatorStatus();
                System.Threading.Thread.Sleep(1000); // Simulate time between elevator movements
            }

            // Drop off and pick up passengers
            var passengersToDropOff = Passengers.FindAll(p => p.CurrentFloor == elevator.CurrentFloor);
            foreach (var passenger in passengersToDropOff)
            {
                elevator.DropOffPassenger();
                PeopleWaitingOnFloors[passenger.DestinationFloor - 1]++;
            }

            var passengersToPickUp = Passengers.FindAll(p => p.CurrentFloor == elevator.CurrentFloor && p.DestinationFloor != elevator.CurrentFloor);
            foreach (var passenger in passengersToPickUp)
            {
                if (elevator.NumPeopleInside < 4) // Elevator can hold up to 4 people
                {
                    elevator.PickUpPassenger();
                    PeopleWaitingOnFloors[elevator.CurrentFloor - 1]--;
                }
            }

            elevatorPool.ReturnElevator(elevator);
        }

        public void PrintElevatorStatus()
        {
            Console.Clear();
            Console.WriteLine("Elevator Status:");
            int i = 1;
            foreach (var elevator in elevatorPool.GetElevators())
            {
                Console.WriteLine($"Elevator {i++} - Floor: {elevator.CurrentFloor}, Direction: {elevator.Direction}, People Inside: {elevator.NumPeopleInside}");
            }

            Console.WriteLine("\nPeople Waiting on Floors:");
            for (int j = 0; j < NumberOfFloors; j++)
            {
                Console.WriteLine($"Floor {j + 1}: {PeopleWaitingOnFloors[j]}");
            }
        }
    }

}
