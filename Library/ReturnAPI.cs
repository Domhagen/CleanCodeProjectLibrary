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
        public ReturnBookErrorCodes ReturnBook(int customerNumber, int bookNumber, int Condition)
        {
            if (BookConditionOne(Condition) == true)
                return ReturnBookErrorCodes.BookConditionIsOne;
            if (BookConditionTwo(Condition) == true)
                return ReturnBookErrorCodes.BookConditionIsTwo;
            if (BookConditionThree(Condition) == true)
                return ReturnBookErrorCodes.BookConditionIsThree;
            if (BookConditionFour(Condition) == true)
                return ReturnBookErrorCodes.BookConditionIsFour;
            if (BookConditionFive(Condition) == true)
                return ReturnBookErrorCodes.BookConditionIsFive;

            returnManager.ReturnBookFromCustomer(bookNumber, customerNumber, Condition);
            return ReturnBookErrorCodes.Ok;

        }
        private static bool BookConditionOne(int Condition)
        {
            int n = Condition;
            if (n != 1)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private static bool BookConditionTwo(int Condition)
        {
            int n = Condition;
            if (n != 2)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private static bool BookConditionThree(int Condition)
        {
            int n = Condition;
            if (n != 3)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private static bool BookConditionFour(int Condition)
        {
            int n = Condition;
            if (n != 4)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
        private static bool BookConditionFive(int Condition)
        {
            int n = Condition;
            if (n != 5)
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
