using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Person
    {
        public int CurrentFloor { get; private set; }
        public int TargetFloor { get; private set; }

        public Person(int currentFloor, int targetFloor)
        {
            CurrentFloor = currentFloor;
            TargetFloor = targetFloor;
        }
    }

}
