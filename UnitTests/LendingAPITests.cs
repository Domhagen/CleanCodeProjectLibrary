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
                m.LendOutBook(It.IsAny<int>(), It.IsAny<int>()), Times.Once());
        }
        [TestMethod]
        public void TestLendOutBookCustomerHasFiveBooks()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var lendingManagerMock = new Mock<ILendingManager>();

            customerManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(1))
                    .Returns(new Customer
                    {
                        CustomerNumber = 1,
                        Debt = new List<Debt>(),
                        Book = new List<Book>
                        {
                            new Book()
                            {
                                BookID = 1
                            },
                            new Book()
                            {
                                BookID = 2
                            },
                            new Book()
                            {
                                BookID = 3
                            },
                            new Book()
                            {
                                BookID = 4
                            },
                            new Book()
                            {
                                BookID = 5
                            },
                        }
                    });

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
                    });
            var lendingAPI = new LendingAPI(lendingManagerMock.Object, bookManagerMock.Object, customerManagerMock.Object);
            var result = lendingAPI.LendOutBook(7, 1);
            Assert.AreEqual(LendOutBookErrorCodes.CustomerHasFiveBooks, result);
            lendingManagerMock.Verify(m =>
                m.LendOutBook(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }
        [TestMethod]
        public void TestLendOutBookCustomerHasDebts()
        {
            var bookManagerMock = new Mock<IBookManager>();
            var customerManagerMock = new Mock<ICustomerManager>();
            var lendingManagerMock = new Mock<ILendingManager>();

            customerManagerMock.Setup(m =>
                m.GetCustomerByCustomerNumber(1))
                    .Returns(new Customer
                    {
                        CustomerNumber = 1,
                        Debt = new List<Debt>
                        {
                            new Debt()
                            {
                                DebtNumber = 1
                            }
                        },
                        Book = new List<Book>
                        {
                            new Book()
                            {
                                BookID = 1
                            }
                        }
                    });

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
                    });
            var lendingAPI = new LendingAPI(lendingManagerMock.Object, bookManagerMock.Object, customerManagerMock.Object);
            var result = lendingAPI.LendOutBook(1, 1);
            Assert.AreEqual(LendOutBookErrorCodes.CustomerHasDebt, result);
            lendingManagerMock.Verify(m =>
                m.LendOutBook(It.IsAny<int>(), It.IsAny<int>()), Times.Never());
        }
    }
}
