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
        public void ReturnBookFromCustomer(int bookID, int customerID)
        {
            using var context = new LibraryContext();
            var book = (from b in context.Books
                         where b.BookID == bookID
                         select b)
                         .First();
            book.CustomerID = customerID;
            context.Books.Remove(book);
            context.SaveChanges();
        }
    }
}
