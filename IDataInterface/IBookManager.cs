using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IBookManager
    {
        void AddBook(int bookNumber);
        Book GetBookByBookNumber(int bookNumber);
        void MoveBook(int bookID, int shelfID);
    }
}
