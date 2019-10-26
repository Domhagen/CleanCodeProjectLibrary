using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class BookManager : IBookManager
    {
        public void AddBook(int bookNumber)
        {
            using var context = new LibraryContext();
            var book = new Book();
            book.BookNumber = bookNumber;
            context.Books.Add(book);
            context.SaveChanges();
        }
    }
}
