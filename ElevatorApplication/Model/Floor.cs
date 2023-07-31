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
        public List<Person> WaitingPeople { get; private set; }

        public Floor(int floorNumber)
        {
            FloorNumber = floorNumber;
            WaitingPeople = new List<Person>();
        }

        public void AddPerson(Person person)
        {
            WaitingPeople.Add(person);
        }
    }
}
