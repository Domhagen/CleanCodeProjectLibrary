using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IReturnManager
    {
        void ReturnBookFromCustomer(int bookID, int customerID);
    }
}
