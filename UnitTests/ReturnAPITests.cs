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
            var bookManager = new Mock<IBookManager>();
            var returnManager = new Mock<IReturnManager>();
            var customerManager = new Mock<ICustomerManager>();
            var returnAPI = new ReturnAPI(customerManager.Object, returnManager.Object, bookManager.Object);
            var successfull = returnAPI.ReturnBook(0, 0);
            Assert.AreEqual(ReturnBookErrorCodes.Ok, successfull);
            returnManager.Verify(m =>
                m.ReturnBookFromCustomer(0, 0), Times.Once);
        }
    }
}
