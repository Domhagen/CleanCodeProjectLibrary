using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ReturnManager : IReturnManager
    {
        public Customer GetCustomerByCustomerNumber(int customerNumber)
        {
            using var context = new LibraryContext();
            return (from c in context.Customers
                    where c.CustomerNumber == customerNumber
                    select c)
                    .Include(b => b.Book)
                    .Include(d => d.Debt)
                    .FirstOrDefault();

        }
        public void ReturnBookFromCustomer(int bookID, int customerID, int bookCondition)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                         where b.BookID == bookID
                         select b)
                         .Include(bc => bc.Condition)
                         .First();
            book.CustomerID = customerID;
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}
