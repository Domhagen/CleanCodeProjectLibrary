using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class BookManager : IBookManager
    {
        public void AddBook(int bookNumber, string bookTitle, string bookAuthor, string isbnNumber)
        {
            using var context = new LibraryContext();
            var book = new Book();
            book.Title = bookTitle;
            book.Author = bookAuthor;
            book.ISBN = isbnNumber;
            book.BookNumber = bookNumber;
            context.Books.Add(book);
            context.SaveChanges();
        }
        public Book GetBookByBookNumber(int bookNumber)
        {
            using var context = new LibraryContext();
            return (from b in context.Books
                    where b.BookNumber == bookNumber
                    select b)
                    .Include(b => b.Shelf)
                    .FirstOrDefault();
        }
        public void MoveBook(int bookID, int shelfID)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                        where b.BookID == bookID
                        select b)
                        .First();
            book.ShelfID = shelfID;
            context.SaveChanges();
        }
    }
}
