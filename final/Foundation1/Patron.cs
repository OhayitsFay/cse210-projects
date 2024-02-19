// Patron class represents library patrons
class Patron
{
    public string Name { get; }
    public int ID { get; }
    public List<Book> BorrowedBooks { get; }

    public Patron(string name, int id)
    {
        Name = name;
        ID = id;
        BorrowedBooks = new List<Book>();
    }

    public void BorrowBook(Book book)
    {
        if (book.IsAvailable)
        {
            BorrowedBooks.Add(book);
            book.IsAvailable = false;
            Console.WriteLine($"{Name} borrowed book: {book.Title}");
        }
        else
        {
            Console.WriteLine($"{Name} cannot borrow book '{book.Title}' as it is not available.");
        }
    }

    public void ReturnBook(Book book)
    {
        if (BorrowedBooks.Contains(book))
        {
            BorrowedBooks.Remove(book);
            book.IsAvailable = true;
            Console.WriteLine($"{Name} returned book: {book.Title}");
        }
        else
        {
            Console.WriteLine($"{Name} cannot return book '{book.Title}' as it is not borrowed.");
        }
    }
}