using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using System.Linq;

namespace Library
{
    public class ScraplistAPI
    {
        private IScraplistManager scraplistManagerMock;
        private IBookManager bookManagerMock;
        public ScraplistAPI(IScraplistManager scraplistManagerMock, IBookManager bookManagerMock)
        {
            this.scraplistManagerMock = scraplistManagerMock;
            this.bookManagerMock = bookManagerMock;
        }
        public ScraplistErrorCodes GetScraplist()
        {
            var books = bookManagerMock.GetAllBooks();
            var trashBooks = GetAllTrashBooks(books);
            if (trashBooks == null)
                return ScraplistErrorCodes.ThereAreNoTrashBooks;
            scraplistManagerMock.GetScraplist();
            return ScraplistErrorCodes.Ok;
        }
        private static IEnumerable<Book> GetAllTrashBooks(List<Book> books)
        {
            return books.Where(b => b.Condition == 1);
        }
    }
}