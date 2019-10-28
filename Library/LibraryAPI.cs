using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using DataAccess;

namespace Library
{
    public class LibraryAPI
    {
        private IAisleManager aisleManager;
        private IShelfManager shelfManager;
        private IBookManager bookManager;

        public LibraryAPI(IAisleManager aisleManager, IShelfManager shelfManager, IBookManager bookManager)
        {
            this.aisleManager = aisleManager;
            this.shelfManager = shelfManager;
            this.bookManager = bookManager;
        }
        public bool AddAisle(int aisleNumber)
        {
            var avaibleAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (avaibleAisle != null)
                return false;
            aisleManager.AddAisle(aisleNumber);
                return true;
        }

        public RemoveAisleErrorCodes RemoveAisle(int aisleNumber)
        {
            var newAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (newAisle == null)
                return RemoveAisleErrorCodes.NoSuchAisle;

            if (newAisle.Shelf.Count > 0)
                return RemoveAisleErrorCodes.AisleHasShelves;

            aisleManager.RemoveAisle(newAisle.AisleID);

            return RemoveAisleErrorCodes.Ok;
        }
        public bool AddShelf(int shelfNumber)
        {
            var avaibleShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (avaibleShelf != null)
                return false;
            shelfManager.AddShelf(shelfNumber);
            return true;
        }

        public MoveShelfErrorCodes MoveShelf(int shelfNumber, int aisleNumber)
        {
            var newAisle = aisleManager.GetAisleByAisleNumber(aisleNumber);
            if (newAisle == null)
                return MoveShelfErrorCodes.NoSuchAisle;
            
            var shelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (shelf == null)
                return MoveShelfErrorCodes.NoSuchShelf;

            if (shelf.Aisle.AisleNumber == aisleNumber)
                return MoveShelfErrorCodes.ShelfAlreadyInThatAisle;

            shelfManager.MoveShelf(shelf.ShelfID, newAisle.AisleID);
            
            return MoveShelfErrorCodes.Ok;
        }
        public RemoveShelfErrorCodes RemoveShelf(int shelfNumber)
        {
            var newShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (newShelf == null)
                return RemoveShelfErrorCodes.NoSuchShelf;

            if (newShelf.Book.Count > 0)
                return RemoveShelfErrorCodes.ShelfHasBooks;

            shelfManager.RemoveShelf(newShelf.ShelfID);

            return RemoveShelfErrorCodes.Ok;
        }
        public bool AddBook(int bookNumber)
        {
            var existingBook = bookManager.GetBookByBookNumber(bookNumber);
            if (existingBook != null)
                return false;
            bookManager.AddBook(bookNumber);

            return true;
        }
        public MoveBookErrorCodes MoveBook(int bookNumber, int shelfNumber)
        {
            var newShelf = shelfManager.GetShelfByShelfNumber(shelfNumber);
            if (newShelf == null)
                return MoveBookErrorCodes.NoSuchShelf;

            var book = bookManager.GetBookByBookNumber(bookNumber);
            if (book == null)
                return MoveBookErrorCodes.NoSuchBook;
            if (book.Shelf.ShelfNumber == shelfNumber)
                return MoveBookErrorCodes.BookAlreadyAtThatShelf;

            bookManager.MoveBook(book.BookID, newShelf.ShelfID);

            return MoveBookErrorCodes.Ok;

        }
    }
}
