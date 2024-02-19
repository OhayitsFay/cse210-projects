// Library class manages the collection of books
class Library
{
    private List<Book> books;

    public Library()
    {
        books = new List<Book>();
    }

    public void AddBook(Book book)
    {
        books.Add(book);
        Console.WriteLine($"Book '{book.Title}' added to the library.");
    }

    public void RemoveBook(string title)
    {
        Book bookToRemove = FindBook(title);
        if (bookToRemove != null)
        {
            books.Remove(bookToRemove);
            Console.WriteLine($"Book '{title}' removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book '{title}' not found in the library.");
        }
    }

    public Book FindBook(string title)
    {
        return books.Find(b => b.Title == title);
    }
}