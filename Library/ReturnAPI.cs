using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class ReturnAPI
    {
        private ICustomerManager customerManager;
        private IBookManager bookManager;
        private IReturnManager returnManager;

        public ReturnAPI(ICustomerManager customerManager, IReturnManager returnManager, IBookManager bookManager)
        {
            this.customerManager = customerManager;
            this.bookManager = bookManager;
            this.returnManager = returnManager;
        }
        public ReturnBookErrorCodes ReturnBook(int customerNumber, int bookNumber)
        {
            var customer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            if (customer == null)
                return ReturnBookErrorCodes.NoSuchCustomer;

            var book = bookManager.GetBookByBookNumber(bookNumber);
            if (book == null)
                return ReturnBookErrorCodes.NoSuchBook;
            if (book.Customer.CustomerNumber == customerNumber)
                return ReturnBookErrorCodes.CustomerHaveTheBook;

            returnManager.ReturnBookFromCustomer(book.BookID, customer.CustomerID);

            return ReturnBookErrorCodes.Ok;
        }
    }
}
