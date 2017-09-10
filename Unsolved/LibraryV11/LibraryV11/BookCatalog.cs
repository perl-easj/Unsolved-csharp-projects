using System;
using System.Collections.Generic;

namespace LibraryV11
{
    /// <summary>
    /// This class represents a collection of Book objects,
    /// for instance the books in a library
    /// </summary>
    public class BookCatalog
    {
        #region Instance fields
        private Dictionary<string, Book> _books;
        #endregion

        #region Constructor
        public BookCatalog()
        {
            _books = new Dictionary<string, Book>();
        }
        #endregion

        #region Methods
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
            return matchingBook;
        } 
        #endregion
    }
}