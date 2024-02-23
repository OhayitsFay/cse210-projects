using System;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Shape Calculator");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Calculate Circle");
            Console.WriteLine("2. Calculate Rectangle");
            Console.WriteLine("3. Calculate Triangle");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CalculateCircleActivity();
                    break;
                case "2":
                    CalculateRectangleActivity();
                    break;
                case "3":
                    CalculateTriangleActivity();
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

    static void CalculateCircleActivity()
    {
        CommonStartingMessage("Calculate Circle", "This activity allows you to calculate the area and perimeter of a circle.");

        // Get input from the user
        Console.Write("Enter the radius of the circle: ");
        double radius = double.Parse(Console.ReadLine());

        // Create a circle object
        Circle circle = new Circle(radius);

        // Display the calculated results
        Console.WriteLine($"Area of the circle: {circle.CalculateArea()}");
        Console.WriteLine($"Perimeter of the circle: {circle.CalculatePerimeter()}");

        CommonEndingMessage("Calculate Circle");
    }

    static void CalculateRectangleActivity()
    {
        CommonStartingMessage("Calculate Rectangle", "This activity allows you to calculate the area and perimeter of a rectangle.");

        // Get input from the user
        Console.Write("Enter the length of the rectangle: ");
        double length = double.Parse(Console.ReadLine());
        Console.Write("Enter the width of the rectangle: ");
        double width = double.Parse(Console.ReadLine());

        // Create a rectangle object
        Rectangle rectangle = new Rectangle(length, width);

        // Display the calculated results
        Console.WriteLine($"Area of the rectangle: {rectangle.CalculateArea()}");
        Console.WriteLine($"Perimeter of the rectangle: {rectangle.CalculatePerimeter()}");

        CommonEndingMessage("Calculate Rectangle");
    }

    static void CalculateTriangleActivity()
    {
        CommonStartingMessage("Calculate Triangle", "This activity allows you to calculate the area and perimeter of a triangle.");

        // Get input from the user
        Console.Write("Enter the length of side 1: ");
        double side1 = double.Parse(Console.ReadLine());
        Console.Write("Enter the length of side 2: ");
        double side2 = double.Parse(Console.ReadLine());
        Console.Write("Enter the length of side 3: ");
        double side3 = double.Parse(Console.ReadLine());

        // Create a triangle object
        Triangle triangle = new Triangle(side1, side2, side3);

        // Display the calculated results
        Console.WriteLine($"Area of the triangle: {triangle.CalculateArea()}");
        Console.WriteLine($"Perimeter of the triangle: {triangle.CalculatePerimeter()}");

        CommonEndingMessage("Calculate Triangle");
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
}