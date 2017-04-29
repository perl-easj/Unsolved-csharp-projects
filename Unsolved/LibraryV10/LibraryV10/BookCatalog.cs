using System;
using System.Collections.Generic;

namespace LibraryV10
{
    public class BookCatalog
    {
        private List<Book> _books;

        public BookCatalog()
        {
            _books = new List<Book>();
        }

        public void AddBook(Book aBook)
        {
            // Add code that can add the given Book object to the list
        }

        public void PrintAllBooks()
        {
            // Add code that can print all books in the list
            // Hint: You will need a repetition statement
        }

        public Book LookupBook(string isbn)
        {
            Book matchingBook = null;

            // Add code that will find a book (if any) in the list
            // which has a matching ISBN number. The variable matchingBook
            // should be set to this book
            // Hint: You will need a repetition statement

            return matchingBook;
        }
    }
}