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
        public AddBookErrorCodes AddBook(int bookNumber, string bookTitle, string bookAuthor, string isbnNumber)
        {

            if (string.IsNullOrEmpty(isbnNumber))
                return AddBookErrorCodes.ThereIsNoISBNumber;
            if (ValidateISBN(isbnNumber) == false)
                return AddBookErrorCodes.ISBNNumberNotValid;
            if (string.IsNullOrEmpty(bookAuthor))
                return AddBookErrorCodes.BookNotGivenAnAuthor;
            if (string.IsNullOrEmpty(bookTitle))
                return AddBookErrorCodes.BookNotGivenATitle;

            bookManager.AddBook(bookNumber, bookTitle, bookAuthor, isbnNumber);
            return AddBookErrorCodes.Ok;
        }
        private static bool ValidateISBN(string isbnNumber)
        {
            string ISBNNumber = isbnNumber.Replace("-", "").Replace(" ", "");
            long n = ISBNNumber.Length;
            if (n != 13)
            {
                return false;
            }

            long ISBNConvertToLong = Int64.Parse(ISBNNumber);

            long tal1mod = ISBNConvertToLong % 1000000000000;
            long tal1 = (ISBNConvertToLong - tal1mod) / 1000000000000;
            long tal2mod = tal1mod % 100000000000;
            long tal2 = (tal1mod - tal2mod) / 100000000000;
            long tal2x3 = tal2 * 3;
            long tal3mod = tal2mod % 10000000000;
            long tal3 = (tal2mod - tal3mod) / 10000000000;
            long tal4mod = tal3mod % 1000000000;
            long tal4 = (tal3mod - tal4mod) / 1000000000;
            long tal4x3 = tal4 * 3;
            long tal5mod = tal4mod % 100000000;
            long tal5 = (tal4mod - tal5mod) / 100000000;
            long tal6mod = tal5mod % 10000000;
            long tal6 = (tal5mod - tal6mod) / 10000000;
            long tal6x3 = tal6 * 3;
            long tal7mod = tal6mod % 1000000;
            long tal7 = (tal6mod - tal7mod) / 1000000;
            long tal8mod = tal7mod % 100000;
            long tal8 = (tal7mod - tal8mod) / 100000;
            long tal8x3 = tal8 * 3;
            long tal9mod = tal8mod % 10000;
            long tal9 = (tal8mod - tal9mod) / 10000;
            long tal10mod = tal9mod % 1000;
            long tal10 = (tal9mod - tal10mod) / 1000;
            long tal10x3 = tal10 * 3;
            long tal11mod = tal10mod % 100;
            long tal11 = (tal10mod - tal11mod) / 100;
            long tal12mod = tal11mod % 10;
            long tal12 = (tal11mod - tal12mod) / 10;
            long tal12x3 = tal12 * 3;

            long totalSumma = tal1 + tal2x3 + tal3 + tal4x3 + tal5 + tal6x3
                + tal7 + tal8x3 + tal9 + tal10x3 + tal11 + tal12x3;

            long totalSummaMod10 = totalSumma % 10;
            long validateNr = 10 - totalSummaMod10;

            long ISBNTal13 = ISBNConvertToLong % 10;
            long ISBNUtanKontrollsiffran = (ISBNConvertToLong - ISBNTal13);
            long newISBN = ISBNUtanKontrollsiffran + validateNr;
            
            if(newISBN == ISBNConvertToLong)
            {
                return true;
            }
            else
            {
                return false;
            }
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
