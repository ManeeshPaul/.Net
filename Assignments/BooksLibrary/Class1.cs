namespace BooksLibrary
{
    public class Book
    {
        // Properties
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string ISBNNo { get; set; }
        public double Price { get; set; }
        public string Publisher { get; set; }
        public int NumberOfPages { get; set; }
        public string Language { get; set; }
        public string LoT { get; set; }
        public string Summary { get; set; }

        // Constructor
        public Book(int id, string name, string isbn, double price, string publisher,
                    int pages, string language = "English", string lot = "Technical", string summary = "")
        {
            BookID = id;
            BookName = name;
            ISBNNo = isbn;
            Price = price;
            Publisher = publisher;
            NumberOfPages = pages;
            Language = language;
            LoT = lot;
            Summary = summary;
        }

        // Method to accept book details
        public void AcceptBookDetails()
        {

            bool isValidInput = false;
            while (!isValidInput)
            {
                Console.WriteLine("Enter Book ID (5 digits): ");
                string inputId = Console.ReadLine();

                bool isIdInteger = int.TryParse(inputId, out int id);

                // Check if input is numeric and exactly 5 digits
                if (isIdInteger && inputId.Length == 5)
                {
                    BookID = id;
                    isValidInput = true;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a 5-digit number.");
                }
            }

            Console.WriteLine("Enter Book Name: ");
            BookName = Console.ReadLine();

            Console.WriteLine("Enter ISBN Number: ");
            ISBNNo = Console.ReadLine();

            Console.WriteLine("Enter Price: ");
            Price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter Publisher: ");
            Publisher = Console.ReadLine();

            Console.WriteLine("Enter Number of Pages: ");
            NumberOfPages = Convert.ToInt32(Console.ReadLine());

            // Validation for Language and LoT
            Console.WriteLine("Enter Language (Press Enter for default 'English'): ");
            Language = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(Language))
            {
                Language = "English";
            }

            // Validation for LoT
            bool isValidLot = false;
            while (!isValidLot)
            {
                Console.WriteLine("Enter LoT (.NET, Java, IMS, V&V, BI, RDBMS): ");
                LoT = Console.ReadLine();

                // Check if LoT is one of the specified values
                // Check if LoT is one of the specified values
                if (LoT.ToLower() == ".net" || LoT.ToLower() == "java" || LoT.ToLower() == "ims" || LoT.ToLower() == "v&v" || LoT.ToLower() == "bi" || LoT.ToLower() == "rdbms")
                {
                    isValidLot = true;
                }
                else
                {
                    Console.WriteLine("Invalid LoT. Please enter one of: .NET, Java, IMS, V&V, BI, RDBMS.");
                }
            }
        }
    }
}