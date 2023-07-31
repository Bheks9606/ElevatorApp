using ElevatorApplication.Model;
using System;
using System.Collections.Generic;


public class Program
{
    public static void Main()
    {
        // Example usage of the elevator simulation
        int numFloors = 5;
        int numElevators = 4;
        int elevatorCapacity = 16;

        Building building = new Building(numFloors, numElevators, elevatorCapacity);

        // Add some people to the floors
        building.AddPersonToFloor(new Person(3, 5), 3);
        building.AddPersonToFloor(new Person(1, 4), 1);
        building.AddPersonToFloor(new Person(2, 1), 2);

        while (true)
        {
            // Show elevator status
            Console.WriteLine("----------Current Elevator Status----------");
            Console.WriteLine("\n");
            for (int i = 0; i < numElevators; i++)
            {
                Elevator elevator = building.Elevators[i];
                Console.WriteLine($"Elevator {i + 1}: Floor: {elevator.CurrentFloor}, " +
                                  $"Direction: {elevator.CurrentDirection}, Moving: {elevator.IsMoving}, " +
                                  $"People inside: {elevator.NumberOfPeopleInside}/{elevator.Capacity}" + "\n");
            }

            Console.WriteLine("\n");
            // Provide options to interact with elevators
            Console.WriteLine("----------Choose an option----------");
            Console.WriteLine("\n");
            Console.WriteLine("1. Call an elevator to a specific floor");
            Console.WriteLine("2. Set the number of people waiting on each floor");
            Console.WriteLine("3. Exit");
            Console.WriteLine("\n");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int option))
            {
                switch (option)
                {
                    case 1:
                        Console.Write("Enter the floor number where you want to call the elevator: ");

                        if (int.TryParse(Console.ReadLine(), out int floorNumber))
                        {
                            // Simulate moving the closest elevator to the specified floor
                            // For simplicity, we'll assume the elevators always start at floor 1.
                            var closestElevator = building.Elevators[0];
                            int minDistance = Math.Abs(closestElevator.CurrentFloor - floorNumber);

                            for (int i = 1; i < numElevators; i++)
                            {
                                int distance = Math.Abs(building.Elevators[i].CurrentFloor - floorNumber);

                                if (distance < minDistance)
                                {
                                    closestElevator = building.Elevators[i];
                                    minDistance = distance;
                                }
                            }

                            closestElevator.MoveToFloor(floorNumber);
                            Console.WriteLine($"Elevator {closestElevator.CurrentFloor} arrived at floor {floorNumber}");
                            Console.WriteLine("\n");
                        }
                        break;

                    case 2:
                        for (int i = 0; i < numFloors; i++)
                        {
                            Console.Write($"Enter the number of people waiting on floor {i + 1}: ");
                            if (int.TryParse(Console.ReadLine(), out int numPeople))
                            {
                                building.Floors[i].WaitingPeople.Clear();
                                for (int j = 0; j < numPeople; j++)
                                {
                                    Console.Write($"Enter the target floor for person {j + 1}: ");
                                    if (int.TryParse(Console.ReadLine(), out int targetFloor))
                                    {
                                        building.AddPersonToFloor(new Person(i + 1, targetFloor), i + 1);
                                    }
                                }
                            }
                        }
                        break;

                    case 3:
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }
        }
    }
}