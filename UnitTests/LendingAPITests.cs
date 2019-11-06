using Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Moq;
using System.Collections.Generic;
using System.Text;
using IDataInterface;

namespace UnitTests
{
    [TestClass]
    public class LendingAPITests
    {
        [TestMethod]
        public void TestLendOutBook()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var lendingManagerMock = new Mock<ILendingManager>();

            customerManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        Book = new List<Book>(),
                        Debt = new List<Debt>()
                    }); ;

            bookManagerMock.Setup(m =>
                m.GetBookByBookNumber(It.IsAny<int>()))
                    .Returns(new Book
                    {
                        BookID = 2,
                        Customer = new Customer()
                    });

            lendingManagerMock.Setup(m =>
                m.GetBookBybookNumber(It.IsAny<int>()))
                    .Returns(new Book
                    {
                        BookID = 2,
                        Customer = new Customer()
                    });

            var lendingAPI = new LendingAPI(lendingManagerMock.Object, bookManagerMock.Object, customerManagerMock.Object);
            var result = lendingAPI.LendOutBook(2, 2);
            Assert.AreEqual(LendOutBookErrorCodes.Ok, result);
            lendingManagerMock.Verify(m =>
                m.LendOutBook(2, 1), Times.Once());
        }
    }
}
