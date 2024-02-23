using System;
using System.Collections.Generic;
using System.Threading;

class Program
{
    // Define lists to store vehicles, cars, and trucks
    static List<Vehicle> vehicles = new List<Vehicle>();
    static List<Car> cars = new List<Car>();
    static List<Truck> trucks = new List<Truck>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Vehicle Rental System");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Manage Vehicles");
            Console.WriteLine("2. Rent a Car");
            Console.WriteLine("3. Rent a Truck");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformVehicleManagementActivity();
                    break;
                case "2":
                    PerformCarRentalActivity();
                    break;
                case "3":
                    PerformTruckRentalActivity();
                    break;
                case "4":
                    Console.WriteLine("Exiting...");
                    Thread.Sleep(2000); // Pause for 2 seconds before exiting
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void PerformVehicleManagementActivity()
    {
        CommonStartingMessage("Manage Vehicles", "This activity allows you to manage the rental of different types of vehicles.");

        // Add vehicles
        vehicles.Add(new Vehicle("Toyota", "Camry", 2022, 50.00));
        vehicles.Add(new Vehicle("Ford", "F-150", 2021, 80.00));

        // Add cars
        cars.Add(new Car("Honda", "Civic", 2020, 60.00, 4, 5));
        cars.Add(new Car("Chevrolet", "Malibu", 2021, 70.00, 4, 5));

        // Add trucks
        trucks.Add(new Truck("Ford", "F-250", 2020, 100.00, 1000, 8000));
        trucks.Add(new Truck("Chevrolet", "Silverado", 2019, 120.00, 1200, 9000));

        Console.WriteLine("Vehicles added successfully.");

        // Display all vehicles
        Console.WriteLine("All Vehicles:");
        foreach (var vehicle in vehicles)
        {
            Console.WriteLine($"Make: {vehicle.Make}, Model: {vehicle.Model}, Year: {vehicle.Year}, Rental Price: ${vehicle.RentalPrice}");
        }

        CommonEndingMessage("Manage Vehicles");
    }

    static void PerformCarRentalActivity()
    {
        CommonStartingMessage("Rent a Car", "This activity allows you to rent a car based on availability and rental duration.");

        // Assume user selects the first car in the list for rental
        Car selectedCar = cars.Count > 0 ? cars[0] : null;

        if (selectedCar != null)
        {
            Console.WriteLine($"You have rented the following car: {selectedCar.Make} {selectedCar.Model}");

            // Implement rental duration logic here
            double rentalDuration = GetRentalDuration(); // In days
            double rentalFees = rentalDuration * selectedCar.RentalPrice;
            Console.WriteLine($"Total Rental Fees: ${rentalFees}");
        }
        else
        {
            Console.WriteLine("No cars available for rental.");
        }

        CommonEndingMessage("Rent a Car");
    }

    static void PerformTruckRentalActivity()
    {
        CommonStartingMessage("Rent a Truck", "This activity allows you to rent a truck based on availability and rental duration.");

        // Assume user selects the first truck in the list for rental
        Truck selectedTruck = trucks.Count > 0 ? trucks[0] : null;

        if (selectedTruck != null)
        {
            Console.WriteLine($"You have rented the following truck: {selectedTruck.Make} {selectedTruck.Model}");

            // Implement rental duration logic here
            double rentalDuration = GetRentalDuration(); // In days
            double rentalFees = rentalDuration * selectedTruck.RentalPrice;
            Console.WriteLine($"Total Rental Fees: ${rentalFees}");
        }
        else
        {
            Console.WriteLine("No trucks available for rental.");
        }

        CommonEndingMessage("Rent a Truck");
    }

    static void CommonStartingMessage(string activityName, string description)
    {
        Console.Clear();
        Console.WriteLine($"Activity: {activityName}");
        Console.WriteLine($"Description: {description}");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds
    }

    static void CommonEndingMessage(string activityName)
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"Activity completed: {activityName}");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static double GetRentalDuration()
    {
        Console.Write("Enter rental duration (in days): ");
        double duration;
        while (!double.TryParse(Console.ReadLine(), out duration) || duration <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a valid positive number for rental duration.");
            Console.Write("Enter rental duration (in days): ");
        }
        return duration;
    }
}