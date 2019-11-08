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
            var successfull = returnAPI.ReturnBook(1, 1, 0);
            Assert.AreEqual(ReturnBookErrorCodes.Ok, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Once);
        }
        [TestMethod]
        public void TestReturnBookWhereBookConditionIsOne()
        {
            var returnManagerMock = new Mock<IReturnManager>();
            var bookMangerMock = new Mock<IBookManager>();

            returnManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        CustomerNumber = 1,
                        Book = new List<Book>(),
                    }); ;

            var returnAPI = new ReturnAPI(returnManagerMock.Object);
            var successfull = returnAPI.ReturnBook(1, 1, 1);
            Assert.AreEqual(ReturnBookErrorCodes.BookConditionIsOne, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestReturnBookWhereBookConditionIsTwo()
        {
            var returnManagerMock = new Mock<IReturnManager>();
            var bookMangerMock = new Mock<IBookManager>();

            returnManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        CustomerNumber = 1,
                        Book = new List<Book>(),
                    }); ;

            var returnAPI = new ReturnAPI(returnManagerMock.Object);
            var successfull = returnAPI.ReturnBook(1, 1, 2);
            Assert.AreEqual(ReturnBookErrorCodes.BookConditionIsTwo, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestReturnBookWhereBookConditionIsThree()
        {
            var returnManagerMock = new Mock<IReturnManager>();
            var bookMangerMock = new Mock<IBookManager>();

            returnManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        CustomerNumber = 1,
                        Book = new List<Book>(),
                    }); ;

            var returnAPI = new ReturnAPI(returnManagerMock.Object);
            var successfull = returnAPI.ReturnBook(1, 1, 3);
            Assert.AreEqual(ReturnBookErrorCodes.BookConditionIsThree, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestReturnBookWhereBookConditionIsFour()
        {
            var returnManagerMock = new Mock<IReturnManager>();
            var bookMangerMock = new Mock<IBookManager>();

            returnManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        CustomerNumber = 1,
                        Book = new List<Book>(),
                    }); ;

            var returnAPI = new ReturnAPI(returnManagerMock.Object);
            var successfull = returnAPI.ReturnBook(1, 1, 4);
            Assert.AreEqual(ReturnBookErrorCodes.BookConditionIsFour, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
        [TestMethod]
        public void TestReturnBookWhereBookConditionIsFive()
        {
            var returnManagerMock = new Mock<IReturnManager>();
            var bookMangerMock = new Mock<IBookManager>();

            returnManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                    .Returns(new Customer
                    {
                        CustomerID = 1,
                        CustomerNumber = 1,
                        Book = new List<Book>(),
                    }); ;

            var returnAPI = new ReturnAPI(returnManagerMock.Object);
            var successfull = returnAPI.ReturnBook(1, 1, 5);
            Assert.AreEqual(ReturnBookErrorCodes.BookConditionIsFive, successfull);
            returnManagerMock.Verify(m =>
                m.ReturnBookFromCustomer(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<int>()), Times.Never);
        }
    }
}
