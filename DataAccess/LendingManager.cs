using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class LendingManager : ILendingManager
    {
        public TimeSlot FindAvaibleBook(int bookNumber ,DateTime start)
        {
            var context = new LibraryContext();
            var books = (from b in context.Books
                         where b.BookNumber == bookNumber
                         select b);
            var timeSlots = (from t in context.TimeSlots
                             where books.Any(b =>
                             t.Lending.All(le =>
                             le.BookID != b.BookID))
                             && t.Start >= start
                             orderby t.Start
                             select t);
            return timeSlots.FirstOrDefault();
        }
        public Book LendOutBookByBookTitle(string bookTitle)
        {
            using var context = new LibraryContext();
            return (from b in context.Books
                    where b.BookTitle == bookTitle
                    select b)
                    .FirstOrDefault();
        }
    }
}
