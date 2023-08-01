using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Floor
    {
        public int FloorNumber { get; private set; }
        public List<Passenger> WaitingPeople { get; private set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            WaitingPeople = new List<Passenger>();
        }

        public void AddPerson(Passenger person)
        {
            WaitingPeople.Add(person);
        }
    }
}
