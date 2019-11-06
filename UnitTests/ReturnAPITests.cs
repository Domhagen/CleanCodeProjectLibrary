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
        public void TestReturnBookFromCustomer()
        {
            var returnManagerMock = new Mock<IReturnManager>();

            returnManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        Book = new List<Book>(),
                    }); ;

            var returnAPI = new ReturnAPI( returnManagerMock.Object);
            var successfull = returnAPI.ReturnBook(1, 1, 2);
            Assert.AreEqual(ReturnBookErrorCodes.Ok, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(1, 1, 2), Times.Once);
        }
    }
}
