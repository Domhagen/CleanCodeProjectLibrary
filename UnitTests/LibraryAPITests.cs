using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using IDataInterface;
using Library;
using System.Linq;

namespace UnitTests
{
    [TestClass]
    public class LibraryAPITests
    {
        [TestMethod]
        public void TestAddAisle()
        {
            Mock<IAisleManager> aisleManagerMock = SetupMockAisle(null);
            bool successfull = AddAisleNumberOne(aisleManagerMock);
            Assert.IsTrue(successfull);
            aisleManagerMock.Verify(m =>
                m.AddAisle(It.Is<int>(i => i == 1)),
                    Times.Once());
        }
        [TestMethod]
        public void TestAddExistingAisle()
        {
            var aisleManagerMock = SetupMockAisle(new Aisle());
            bool successfull = AddAisleNumberOne(aisleManagerMock);
            Assert.IsFalse(successfull);
            aisleManagerMock.Verify(m =>
                m.AddAisle(It.Is<int>(i => i == 1)),
                    Times.Never());
        }
        [TestMethod]
        public void TestRemoveEmptyAisle()
        {
            var aisleManagerMock = new Mock<IAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            aisleManagerMock.Setup(m =>
            m.GetAisleByAisleNumber(It.IsAny<int>()))
                .Returns(new Aisle 
                { 
                    AisleNumber = 2,
                    Shelf = new List<Shelf>()
                });

            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, shelfManagerMock.Object, null, null);
            var successfull = libraryAPI.RemoveAisle(2);
            Assert.AreEqual(RemoveAisleErrorCodes.Ok, successfull);
            aisleManagerMock.Verify(m => 
                m.RemoveAisle(It.IsAny<int>()), Times.Once);
        }
        [TestMethod]
        public void TestRemoveAisleWithOneShelf()
        {
            var aisleManagerMock = new Mock<IAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            aisleManagerMock.Setup(m =>
            m.GetAisleByAisleNumber(It.IsAny<int>()))
                .Returns(new Aisle 
                { 
                    AisleNumber = 4, 
                    Shelf = new List<Shelf>
                    {
                        new Shelf()
                    }
                });

            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, shelfManagerMock.Object, null, null);
            var successfull = libraryAPI.RemoveAisle(4);
            Assert.AreEqual(RemoveAisleErrorCodes.AisleHasShelves, successfull);
            aisleManagerMock.Verify(m =>
                m.RemoveAisle(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestRemoveNonexistentAisle()
        {
            var aisleManagerMock = new Mock<IAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            aisleManagerMock.Setup(m =>
            m.GetAisleByAisleNumber(It.IsAny<int>()))
                .Returns((Aisle)null);

            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, shelfManagerMock.Object, null, null);
            var successfull = libraryAPI.RemoveAisle(4);
            Assert.AreEqual(RemoveAisleErrorCodes.NoSuchAisle, successfull);
            aisleManagerMock.Verify(m =>
                m.RemoveAisle(It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestAddShelf()
        {
            var shelfManagerMock = new Mock<IShelfManager>();
            var aisleManagerMock = new Mock<IAisleManager>();

            shelfManagerMock.Setup(m =>
            m.AddShelf(It.IsAny<int>()));

            shelfManagerMock.Setup(m =>
            m.GetShelfByShelfNumber(It.IsAny<int>()));

            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, shelfManagerMock.Object, null, null);
            var successfull = libraryAPI.AddShelf(1);
            Assert.IsTrue(successfull);
            shelfManagerMock.Verify(m =>
                m.AddShelf(It.Is<int>(i => i == 1)),
                    Times.Once());
        }
        [TestMethod]
        public void TestMoveShelf()
        {
            var aisleManagerMock = new Mock<IAisleManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            aisleManagerMock.Setup(m =>
               m.GetAisleByAisleNumber(It.IsAny<int>()))
                .Returns(new Aisle { AisleID = 2 });

            shelfManagerMock.Setup(m =>
                m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(new Shelf 
                { 
                    ShelfID = 2,
                    Aisle = new Aisle()
                });

            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, shelfManagerMock.Object, null, null);
            var result = libraryAPI.MoveShelf(1, 1);
            Assert.AreEqual(MoveShelfErrorCodes.Ok, result);
            shelfManagerMock.Verify(m =>
                m.MoveShelf(2, 2), Times.Once());
        }
        [TestMethod]
        public void TestRemoveEmptyShelf()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            shelfManagerMock.Setup(m =>
            m.GetShelfByShelfNumber(It.IsAny<int>()))
                .Returns(new Shelf
                {
                    ShelfNumber = 4,
                    Book = new List<Book>()
                });

            var libraryAPI = new LibraryAPI(null, shelfManagerMock.Object, bookManagerMock.Object, null);
            var successfull = libraryAPI.RemoveShelf(4);
            Assert.AreEqual(RemoveShelfErrorCodes.Ok, successfull);
            shelfManagerMock.Verify(m =>
                m.RemoveShelf(It.IsAny<int>()), Times.Once);
        }
        private static Mock<IAisleManager> SetupMockAisle(Aisle aisle)
        {
            var aisleManagerMock = new Mock<IAisleManager>();

            aisleManagerMock.Setup(m =>
                    m.GetAisleByAisleNumber(It.IsAny<int>()))
                .Returns(aisle);

            aisleManagerMock.Setup(m =>
                m.AddAisle(It.IsAny<int>()));
            return aisleManagerMock;
        }
        private static bool AddAisleNumberOne(Mock<IAisleManager> aisleManagerMock)
        {
            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, null, null, null);
            var successfull = libraryAPI.AddAisle(1);
            return successfull;
        }
        [TestMethod]
        public void TestAddBook()
        {
            var bookManagerMock = new Mock<IBookManager>();

            bookManagerMock.Setup(m =>
            m.AddBook(It.IsAny<int>(),It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));

            bookManagerMock.Setup(m =>
            m.GetBookByBookNumber(It.IsAny<int>()));

            var libraryAPI = new LibraryAPI(null, null, bookManagerMock.Object, null);
            var successfull = libraryAPI.AddBook(1, "Astrophysics for People in a Hurry", " Neil Degrasse Tyson", "9780393609394", 2);
            Assert.AreEqual(AddBookErrorCodes.Ok,successfull);
            bookManagerMock.Verify(m =>
                m.AddBook(It.Is<int>(i => i == 1), "Astrophysics for People in a Hurry", " Neil Degrasse Tyson", "9780393609394", 2),
                    Times.Once());
        }
        [TestMethod]
        public void TestAddExistingBook()
        {
            var bookManagerMock = SetupMockBook(new Book());
            var libraryAPI = new LibraryAPI(null, null, bookManagerMock.Object, null);
            var successfull = AddBookNumberOne(bookManagerMock);
            Assert.AreEqual(AddBookErrorCodes.Ok,successfull);
            bookManagerMock.Verify(m =>
                m.AddBook(It.Is<int>(i => i == 0), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()),
                Times.Never());
        }

        private static Mock<IBookManager> SetupMockBook(Book book)
        {
            var bookManagerMock = new Mock<IBookManager>();

            bookManagerMock.Setup(m =>
                    m.GetBookByBookNumber(It.IsAny<int>()))
                .Returns(book);

            bookManagerMock.Setup(m =>
                m.AddBook(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>()));
            return bookManagerMock;
        }

        [TestMethod]
        public void TestMoveBook()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            shelfManagerMock.Setup(m =>
                m.GetShelfByShelfNumber(It.IsAny<int>()))
                    .Returns(new Shelf { ShelfID = 2 });

            bookManagerMock.Setup(m =>
                m.GetBookByBookNumber(It.IsAny<int>()))
                    .Returns(new Book
                    {
                        BookID = 2,
                        Shelf = new Shelf()
                    });

            var libraryAPI = new LibraryAPI(null, shelfManagerMock.Object, bookManagerMock.Object, null);
            var result = libraryAPI.MoveBook(1, 1);
            Assert.AreEqual(MoveBookErrorCodes.Ok, result);
            bookManagerMock.Verify(m =>
                m.MoveBook(2, 2), Times.Once());
        }
        private static AddBookErrorCodes AddBookNumberOne(Mock<IBookManager> bookManagerMock)
        {
            var libraryAPI = new LibraryAPI(null, null, bookManagerMock.Object, null);
            var successfull = libraryAPI.AddBook(1, "Astrophysics for People in a Hurry", " Neil Degrasse Tyson", "9780393609394", 2);
            return successfull;
        }
        [TestMethod]
        public void TestRemoveBookWithCustomer()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var customerManagerMock = new Mock<ICustomerManager>();

            bookManagerMock.Setup(m =>
                m.GetBookByBookNumber(It.IsAny<int>()))
                    .Returns(new Book{BookID = 2,});

            customerManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 2,
                        Book = new List<Book>()
                    });

            var libraryAPI = new LibraryAPI(null, null, bookManagerMock.Object, customerManagerMock.Object);
            var successfull = libraryAPI.RemoveBookWithCustomer(2, 1);
            Assert.AreEqual(RemoveBookErrorCodes.Ok, successfull);
            bookManagerMock.Verify(m =>
                m.RemoveBook(It.IsAny<int>()), Times.Once());
        }
    }
}
