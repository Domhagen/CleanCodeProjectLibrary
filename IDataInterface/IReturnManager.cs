using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IReturnManager
    {
        void ReturnBook(int bookID, int customerID, int shelfID);
    }
}
