using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static Library library = new Library();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Library Management System");
            Console.WriteLine("Please select an activity:");
            Console.WriteLine("1. Add a Book");
            Console.WriteLine("2. Remove a Book");
            Console.WriteLine("3. Borrow a Book");
            Console.WriteLine("4. Return a Book");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    PerformAddBookActivity();
                    break;
                case "2":
                    PerformRemoveBookActivity();
                    break;
                case "3":
                    PerformBorrowBookActivity();
                    break;
                case "4":
                    PerformReturnBookActivity();
                    break;
                case "5":
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

    static void PerformAddBookActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Add a Book");
        Console.WriteLine("Description: This activity allows you to add a new book to the library.");
        Console.WriteLine();

        Console.Write("Enter the title of the book: ");
        string title = Console.ReadLine();
        Console.Write("Enter the author of the book: ");
        string author = Console.ReadLine();
        Console.Write("Enter the genre of the book: ");
        string genre = Console.ReadLine();

        Book newBook = new Book(title, author, genre);
        library.AddBook(newBook);

        CommonEndingMessage("Add a Book");
    }

    static void PerformRemoveBookActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Remove a Book");
        Console.WriteLine("Description: This activity allows you to remove a book from the library.");
        Console.WriteLine();

        Console.Write("Enter the title of the book to remove: ");
        string title = Console.ReadLine();

        library.RemoveBook(title);

        CommonEndingMessage("Remove a Book");
    }

    static void PerformBorrowBookActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Borrow a Book");
        Console.WriteLine("Description: This activity allows a patron to borrow a book from the library.");
        Console.WriteLine();

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your ID: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }

        Patron patron = new Patron(name, id);

        Console.Write("Enter the title of the book to borrow: ");
        string title = Console.ReadLine();
        Book bookToBorrow = library.FindBook(title);
        if (bookToBorrow != null)
        {
            patron.BorrowBook(bookToBorrow);
        }
        else
        {
            Console.WriteLine($"Book '{title}' not found in the library.");
        }

        CommonEndingMessage("Borrow a Book");
    }

    static void PerformReturnBookActivity()
    {
        Console.Clear();
        Console.WriteLine("Activity: Return a Book");
        Console.WriteLine("Description: This activity allows a patron to return a borrowed book to the library.");
        Console.WriteLine();

        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your ID: ");
        int id;
        while (!int.TryParse(Console.ReadLine(), out id))
        {
            Console.WriteLine("Invalid ID. Please enter a valid integer ID.");
        }

        Patron patron = new Patron(name, id);

        Console.Write("Enter the title of the book to return: ");
        string title = Console.ReadLine();
        Book bookToReturn = patron.BorrowedBooks.Find(b => b.Title == title);
        if (bookToReturn != null)
        {
            patron.ReturnBook(bookToReturn);
        }
        else
        {
            Console.WriteLine($"You have not borrowed book '{title}'.");
        }

        CommonEndingMessage("Return a Book");
    }

    static void CommonEndingMessage(string activityName)
    {
        Console.WriteLine("Good job!");
        Console.WriteLine($"Activity completed: {activityName}");
        Console.WriteLine();
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}