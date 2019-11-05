using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IBookManager
    {
        void AddBook(int bookNumber, string bookTitle, string bookAuthor, string isbnNumber);
        Book GetBookByBookNumber(int bookNumber);
        void MoveBook(int bookID, int shelfID);
    }
}
