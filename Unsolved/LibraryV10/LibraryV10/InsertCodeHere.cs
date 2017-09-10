using System;

namespace LibraryV10
{
    public class InsertCodeHere
    {
        public void MyCode()
        {
            // The FIRST line of code should be BELOW this line

            Book b1 = new Book("AD1337", "C# for All", "John Potter", 352);
            Book b2 = new Book("XS3220", "Gardening", "Alex Sohn", 220);
            Book b3 = new Book("DD0095", "Cars in the USA", "Susan Dreyer", 528);
            Book b4 = new Book("PT1295", "The World Narrators", "Dan Mygind", 256);

            BookCatalog theCatalog = new BookCatalog();
            theCatalog.AddBook(b1);
            theCatalog.AddBook(b2);
            theCatalog.AddBook(b3);
            theCatalog.AddBook(b4);

            Console.WriteLine("------------- Printing all books ---------------");
            theCatalog.PrintAllBooks();
            Console.WriteLine("------------------------------------------------");
            Console.WriteLine();

            Console.WriteLine(theCatalog.LookupBook("AD1337") == null ? "Book not found..." : theCatalog.LookupBook("AD1337").AllInformation);
            Console.WriteLine(theCatalog.LookupBook("AD1338") == null ? "Book not found..." : theCatalog.LookupBook("AD1338").AllInformation);
            Console.WriteLine(theCatalog.LookupBook("PT1295") == null ? "Book not found..." : theCatalog.LookupBook("PT1295").AllInformation);
            Console.WriteLine(theCatalog.LookupBook("......") == null ? "Book not found..." : theCatalog.LookupBook("......").AllInformation);
            Console.WriteLine(theCatalog.LookupBook("ad1337") == null ? "Book not found..." : theCatalog.LookupBook("ad1337").AllInformation);

            // The LAST line of code should be ABOVE this line
        }
    }
}