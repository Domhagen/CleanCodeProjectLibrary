using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;
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
        public IEnumerable<Book> GetScraplist(int bookCondition)
        {
            return GetAllTrashBooks(1, null);   // <<<------ ändra null till lista
        }
        private static IEnumerable<Book> GetAllTrashBooks(int bookCondition, List<Book> books)
        {
            return books.Where(b => b.Condition == 1);
        }
    }
}