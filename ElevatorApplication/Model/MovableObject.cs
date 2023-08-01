using ElevatorApplication.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public abstract class MovableObject
    {
        public int CurrentFloor { get; set; }
        public int DestinationFloor { get; set; }
        public Direction Direction { get; set; }

        public abstract void MoveUp();

        public abstract void MoveDown();

        public void SetDestinationFloor(int floor)
        {
            DestinationFloor = floor;
            Direction = floor > CurrentFloor ? Direction.Up : Direction.Down;
        }
    }
}
