using ElevatorApplication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Elevator : MovableObject
    {
        public int NumPeopleInside { get; set; }

        public Elevator(int currentFloor)
        {
            CurrentFloor = currentFloor;
            Direction = Direction.Up;
        }

        public override void MoveUp()
        {
            CurrentFloor++;
        }

        public override void MoveDown()
        {
            CurrentFloor--;
        }

        public void PickUpPassenger()
        {
            NumPeopleInside++;
        }

        public void DropOffPassenger()
        {
            NumPeopleInside--;
        }
    }
}
