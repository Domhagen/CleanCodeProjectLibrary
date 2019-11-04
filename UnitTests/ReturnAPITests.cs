using IDataInterface;
using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace UnitTests
{
    [TestClass]
    public class ReturnAPITests
    {
        [TestMethod]
        public void TestReturnOneBook()
        {

        }
        [TestMethod]
        public void TestReturnBook()
        {
            var returnManagerMock = new Mock<IReturnManager>();
            var bookManagerMock = new Mock<IBookManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var shelfManagerMock = new Mock<IShelfManager>();

            customerManagerMock.Setup(m =>
                 m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                  .Returns(new Customer { CustomerID = 5 });

            bookManagerMock.Setup(m =>
                m.GetBookByBookNumber(It.IsAny<int>()))
                 .Returns(new Book
                 {
                     BookID = 2,
                     Shelf = new Shelf()
                 });

            var returnAPI = new ReturnAPI(customerManagerMock.Object, shelfManagerMock.Object, bookManagerMock.Object, returnManagerMock.Object);
            var result = returnAPI.ReturnBook(1, 1, 1);
            Assert.AreEqual(ReturnBookErrorCodes.Ok, result);
            returnManagerMock.Verify(m =>
            m.ReturnBook(2, 2, 2), Times.Once());

        }
        [TestMethod]
        public void TestMoveShelfOk()
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

            var libraryAPI = new LibraryAPI(aisleManagerMock.Object, shelfManagerMock.Object, null);
            var result = libraryAPI.MoveShelf(1, 1);
            Assert.AreEqual(MoveShelfErrorCodes.Ok, result);
            shelfManagerMock.Verify(m =>
            m.MoveShelf(2, 2), Times.Once());
        }
    }
}
