using ElevatorApplication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Elevator
    {
        public int CurrentFloor { get; private set; }
        public int MaxFloors { get; private set; }
        public bool IsMoving { get; private set; }
        public Direction CurrentDirection { get; private set; }
        public int Capacity { get; private set; }
        public int NumberOfPeopleInside { get; private set; }

        public Elevator(int maxFloors, int capacity)
        {
            CurrentFloor = 1;
            MaxFloors = maxFloors;
            IsMoving = false;
            CurrentDirection = Direction.None;
            Capacity = capacity;
            NumberOfPeopleInside = 0;
        }

        public void MoveToFloor(int targetFloor)
        {
            if (targetFloor < 1 || targetFloor > MaxFloors)
                throw new ArgumentException("Invalid floor number");

            CurrentDirection = targetFloor > CurrentFloor ? Direction.Up : Direction.Down;

            // Simulate the movement of the elevator (you can add delay here for realism)
            IsMoving = true;
            Console.WriteLine($"Elevator {CurrentFloor} moving {CurrentDirection} to floor {targetFloor}");
            CurrentFloor = targetFloor;
            IsMoving = false;
            CurrentDirection = Direction.None;
        }

        public bool CanAddPerson()
        {
            return NumberOfPeopleInside < Capacity;
        }

        public void AddPerson()
        {
            if (CanAddPerson())
            {
                NumberOfPeopleInside++;
            }
        }

        public void RemovePerson()
        {
            if (NumberOfPeopleInside > 0)
            {
                NumberOfPeopleInside--;
            }
        }
    }
}
