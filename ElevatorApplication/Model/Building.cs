using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevatorApplication.Model
{
    public class Building
    {
        public List<Elevator> Elevators { get; private set; }
        public List<Floor> Floors { get; private set; }

        public Building(int numFloors, int numElevators, int elevatorCapacity)
        {
            Elevators = new List<Elevator>();
            for (int i = 0; i < numElevators; i++)
            {
                Elevators.Add(new Elevator(numFloors, elevatorCapacity));
            }

            Floors = new List<Floor>();
            for (int i = 1; i <= numFloors; i++)
            {
                Floors.Add(new Floor(i));
            }
        }

        public void AddPersonToFloor(Person person, int floorNumber)
        {
            Floors[floorNumber - 1].AddPerson(person);
        }
    }

}
