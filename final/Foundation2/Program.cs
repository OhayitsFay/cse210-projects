using System;
using System.Collections.Generic;
using System.IO;
class Program
{
    static Dictionary<string, Course> courses = new Dictionary<string, Course>();
    static Dictionary<int, Student> students = new Dictionary<int, Student>();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Student Grading System");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Manage Course");
            Console.WriteLine("2. Calculate Grades");
            Console.WriteLine("3. Manage Students");
            Console.WriteLine("4. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformCourseManagementActivity();
                    break;
                case "2":
                    PerformGradeCalculationActivity();
                    break;
                case "3":
                    PerformStudentManagementActivity();
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

    static void PerformCourseManagementActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Manage Course");
        Console.WriteLine("Description: This activity allows you to manage the grading criteria and assignments for a specific course.");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.Write("Enter the name of the course: ");
        string courseName = Console.ReadLine();

        if (!courses.ContainsKey(courseName))
        {
            courses.Add(courseName, new Course(courseName));
            Console.WriteLine($"Course '{courseName}' created.");
        }
        else
        {
            Console.WriteLine($"Course '{courseName}' already exists.");
        }

        Course currentCourse = courses[courseName];
        Console.WriteLine($"Managing Course: {currentCourse.CourseName}");
        Console.WriteLine("Please select an action:");
        Console.WriteLine("1. Add Assignment");
        Console.WriteLine("2. Remove Assignment");
        Console.WriteLine("3. Display Assignment Weightage");
        Console.WriteLine("4. Back to Main Menu");

        Console.Write("Enter your choice: ");
        string action = Console.ReadLine();

        switch (action)
        {
            case "1":
                Console.Write("Enter assignment name: ");
                string assignmentName = Console.ReadLine();
                Console.Write("Enter assignment weightage: ");
                double assignmentWeightage = double.Parse(Console.ReadLine());
                currentCourse.AddAssignment(assignmentName, assignmentWeightage);
                break;
            case "2":
                Console.Write("Enter assignment name to remove: ");
                string assignmentToRemove = Console.ReadLine();
                currentCourse.RemoveAssignment(assignmentToRemove);
                break;
            case "3":
                currentCourse.DisplayAssignmentWeightage();
                break;
            case "4":
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("Activity completed: Manage Course");
        CommonEndingMessage();
    }

    static void PerformGradeCalculationActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Calculate Grades");
        Console.WriteLine("Description: This activity allows you to calculate overall course grades based on assignment scores and weightage.");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Please select the course:");
        int index = 1;
        foreach (var course in courses)
        {
            Console.WriteLine($"{index}. {course.Key}");
            index++;
        }

        Console.Write("Enter the number corresponding to the course: ");
        int courseNumber = int.Parse(Console.ReadLine());
        string selectedCourseName = courses.Keys.ToArray()[courseNumber - 1];

        Course selectedCourse = courses[selectedCourseName];
        Console.WriteLine($"Calculating Grades for Course: {selectedCourse.CourseName}");

        Dictionary<string, double> assignmentScores = new Dictionary<string, double>();
        foreach (var assignment in selectedCourse.AssignmentWeightage)
        {
            Console.Write($"Enter score for assignment '{assignment.Key}': ");
            double score = double.Parse(Console.ReadLine());
            assignmentScores.Add(assignment.Key, score);
        }

        double overallGrade = GradeCalculator.CalculateOverallGrade(assignmentScores, selectedCourse.AssignmentWeightage);
        Console.WriteLine($"Overall Grade for Course '{selectedCourse.CourseName}': {overallGrade}");

        Console.WriteLine("Activity completed: Calculate Grades");
        CommonEndingMessage();
    }

    static void PerformStudentManagementActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Manage Students");
        Console.WriteLine("Description: This activity allows you to manage individual students with attributes such as name, ID, and grades.");
        Console.WriteLine("Prepare to begin...");
        Thread.Sleep(3000); // Pause for 3 seconds

        Console.WriteLine("Please select an action:");
        Console.WriteLine("1. Add Student");
        Console.WriteLine("2. Display Student Information");
        Console.WriteLine("3. Back to Main Menu");

        Console.Write("Enter your choice: ");
        string action = Console.ReadLine();

        switch (action)
        {
            case "1":
                Console.Write("Enter student name: ");
                string studentName = Console.ReadLine();
                Console.Write("Enter student ID: ");
                int studentID = int.Parse(Console.ReadLine());

                if (!students.ContainsKey(studentID))
                {
                    students.Add(studentID, new Student(studentName, studentID));
                    Console.WriteLine($"Student '{studentName}' added with ID '{studentID}'.");
                }
                else
                {
                    Console.WriteLine($"Student ID '{studentID}' already exists.");
                }
                break;
            case "2":
                Console.Write("Enter student ID to display information: ");
                int idToDisplay = int.Parse(Console.ReadLine());
                if (students.ContainsKey(idToDisplay))
                {
                    students[idToDisplay].DisplayStudentInfo();
                }
                else
                {
                    Console.WriteLine($"Student with ID '{idToDisplay}' not found.");
                }
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }

        Console.WriteLine("Activity completed: Manage Students");
        CommonEndingMessage();
    }

    static void CommonEndingMessage()
    {
        Console.WriteLine("Good job!");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}