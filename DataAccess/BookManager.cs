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
        public void AddBook(int bookNumber, string bookTitle, string bookAuthor, string isbnNumber, int bookCondition)
        {
            using var context = new LibraryContext();
            var book = new Book();
            book.Title = bookTitle;
            book.Author = bookAuthor;
            book.ISBN = isbnNumber;
            book.BookNumber = bookNumber;
            book.Condition = bookCondition;
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
        public List<Book> GetAllBooks()
        {
            using var context = new LibraryContext();
            return (from b in context.Books
                    where !b.Deleted
                    select b)
                    .Include(b => b.Shelf)
                    .ToList();
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
        public void RemoveBook(int bookID)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                         where b.BookID == bookID
                         select b)
                         .Include(b => b.Customer)
                         .FirstOrDefault();
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}
