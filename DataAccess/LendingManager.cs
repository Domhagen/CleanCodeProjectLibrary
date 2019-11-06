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
        public TimeSlot GetAvaibleBook(int bookNumber ,DateTime start)
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
        public Book GetBookBybookNumber(int bookNumber)
        {
            using var context = new LibraryContext();
            return (from b in context.Books
                    where b.BookNumber == bookNumber
                    select b)
                    .Include(b => b.Customer)
                    .FirstOrDefault();
        }
        public void LendOutBook(int bookID, int customerID)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                        where b.BookID == bookID
                        select b)
                        .First();
            book.CustomerID = customerID;
            context.SaveChanges();
        }
        public List<TimeSlot> GetTimeSlotsFrom(DateTime start)
        {
            using var context = new LibraryContext();
            return (from s in context.TimeSlots
                    where s.Start >= start
                    select s).ToList();
        }
    }
}
