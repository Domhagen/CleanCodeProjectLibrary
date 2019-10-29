using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;

namespace Library
{
    public class LendingAPI
    {
        private IBookManager bookManager;

        public LendingAPI(IBookManager bookManager)
        {
            this.bookManager = bookManager;
        }
        public LendOutBookErrorCodes LendOutBook(int bookNumber)
        {
            var book = bookManager.GetBookByBookNumber(bookNumber);
            if (book == null)
                return LendOutBookErrorCodes.BookNotAvaible;

            return LendOutBookErrorCodes.Ok;
        }
    }
}
