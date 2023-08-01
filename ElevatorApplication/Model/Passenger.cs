using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Passenger : MovableObject
    {
        public Passenger(int currentFloor, int destinationFloor)
        {
            CurrentFloor = currentFloor;
            DestinationFloor = destinationFloor;
        }

        public override void MoveUp()
        {
            CurrentFloor++;
        }

        public override void MoveDown()
        {
            CurrentFloor--;
        }
    }

}
