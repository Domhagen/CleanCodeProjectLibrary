using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class ReturnAPI
    {
        private IReturnManager returnManager;

        public ReturnAPI(IReturnManager returnManager)
        {
            this.returnManager = returnManager;
        }
        public ReturnBookErrorCodes ReturnBook(int customerNumber, int bookNumber, int bookCondition)
        {
            if (BookCondition(bookCondition) == false)
                return ReturnBookErrorCodes.BookIsTrash;

            returnManager.ReturnBookFromCustomer(bookNumber, customerNumber, bookCondition);
            return ReturnBookErrorCodes.Ok;

        }
        private static bool BookCondition(int bookCondition)
        {
            int n = bookCondition;
            if (n < 2)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
