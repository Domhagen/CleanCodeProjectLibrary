using IDataInterface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class ReturnAPI
    {
        private ICustomerManager customerManager;
        private IShelfManager shelfManager;
        private IBookManager bookManager;
        private IReturnManager returnManager;

        public ReturnAPI(ICustomerManager customerManager, IShelfManager shelfManager, IBookManager bookManager, IReturnManager returnManager)
        {
            this.customerManager = customerManager;
            this.shelfManager = shelfManager;
            this.bookManager = bookManager;
            this.returnManager = returnManager;
        }
        public ReturnBookErrorCodes ReturnBook(int shelfNumber, int customerNumber, int bookNumber)
        {
            var book = bookManager.GetBookByBookNumber(bookNumber);

            var shelf = shelfManager.GetShelfByShelfNumber(shelfNumber);

            var customer = customerManager.GetCustomerByCustomerNumber(customerNumber);
            /*
            var newAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (newAisle == null)
                return MoveShelfErrorCodes.NoSuchAisle;

            var shelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (shelf == null)
                return MoveShelfErrorCodes.NoSuchShelf;

            if (shelf.Aisle.AisleNumber == aisleNumber)
                return MoveShelfErrorCodes.ShelfAlreadyInThatAisle;
            */

            returnManager.ReturnBook(book.BookID, customer.CustomerID, shelf.ShelfID);

            return ReturnBookErrorCodes.Ok;
        }
    }
}
