using ElevatorApplication.Model;
using System;
using System.Collections.Generic;
 

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Elevator Simulator!");

        // Create a building with 5 floors and 2 elevators starting at the first floor
        Building building = new Building(5, 2, 1);

        // Add passengers with their respective destinations
        building.AddPassenger(1, 3);
        building.AddPassenger(1, 5);
        building.AddPassenger(2, 4);

        while (building.Passengers.Count > 0)
        {
            // Display elevator status and people waiting on floors
            building.PrintElevatorStatus();

            Console.WriteLine("\nSelect an option:");
            Console.WriteLine("1. Call Elevator");
            Console.WriteLine("2. Add People Waiting on Floor");
            Console.WriteLine("3. Exit");

            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the floor to call the elevator:");
                    int floorToCallElevator = int.Parse(Console.ReadLine());
                    building.CallElevator(floorToCallElevator);
                    break;
                case 2:
                    Console.WriteLine("Enter the floor number where people are waiting:");
                    int floorWithPeople = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the number of people waiting on the floor:");
                    int numPeople = int.Parse(Console.ReadLine());
                    building.PeopleWaitingOnFloors[floorWithPeople - 1] = numPeople;
                    break;
                case 3:
                    return;
            }
        }

        Console.WriteLine("All passengers have been dropped off.");
    }
}






        