using System;
using System.Collections.Generic;
using System.Text;

namespace IDataInterface
{
    public interface IBookManager
    {
        void AddBook(int bookNumber, string bookTitle, string bookAuthor, string isbnNumber, int bookCondition);
        Book GetBookByBookNumber(int bookNumber);
        void MoveBook(int bookID, int shelfID);
        void RemoveBook(int bookID);
        List<Book> GetAllBooks();
    }
}
