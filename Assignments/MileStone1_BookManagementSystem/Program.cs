using BooksLibrary;

namespace MileStone1_BookManagementSystem
{
    public class Program
    {
        static void Main()
        {
            List<Book> books = new List<Book>();            //Creating object of Book class

            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add a Book");
                Console.WriteLine("2. Display all Books");
                Console.WriteLine("3. Delete a Book by ID");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                int choice;
                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Invalid choice. Please enter a number.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        AddBook(books);
                        break;
                    case 2:
                        DisplayBooks(books);
                        break;
                    case 3:
                        DeleteBook(books);
                        break;
                    case 4:
                        Console.WriteLine("---Exiting---");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 4.");
                        break;
                }
            }
        }

        // Method to add a new book
        static void AddBook(List<Book> books)
        {
            Book newBook = new Book(0, "", "", 0.0, "", 0); // Initialize with default values
            newBook.AcceptBookDetails();                    // Accept details from user
            books.Add(newBook);                             // Adding to collection
            Console.WriteLine("Book added successfully.");
        }

        // Method to display all books
        static void DisplayBooks(List<Book> books)
        {
            if (books.Count == 0)
            {
                Console.WriteLine("No books available.");
                return;
            }

            foreach (var book in books)
            {
                Console.WriteLine($"Book ID: {book.BookID}, Name: {book.BookName}, ISBN_No: {book.ISBNNo}, Price: {book.Price}, " +
                                  $"Publisher: {book.Publisher}, Pages: {book.NumberOfPages}, Language: {book.Language}, " +
                                  $"LoT: {book.LoT}, Summary: {book.Summary}");
            }
        }

        // Method to delete a book by ID
        static void DeleteBook(List<Book> books)
        {
            Console.WriteLine("Enter Book ID to delete: ");
            int idToDelete = Convert.ToInt32(Console.ReadLine());

            Book bookToDelete = books.Find(b => b.BookID == idToDelete);        //Finding book id is available in the list
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
                Console.WriteLine("Book deleted successfully.");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }
        }
    }
}