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
            ReturnAPI returnAPI = SetupTestData();
            var result = returnAPI.ReturnBook(1, 0);
            Assert.IsTrue(result.Equals(ReturnBookErrorCodes.Ok));
        }
        private static ReturnAPI SetupTestData()
        {
            var returnManager = new Mock<IReturnManager>();
            var customerManager = new Mock<ICustomerManager>();
            var returnAPI = new ReturnAPI(customerManager.Object, returnManager.Object, null);
            customerManager.Setup(m =>
                m.GetAllCustomers())
                 .Returns(new List<Customer>
                 {
                     new Customer
                     {
                         CustomerID = 1,
                         Book = new List<Book>
                         {
                             new Book(),
                             new Book()
                         }
                     }
                 });
            return returnAPI;
        }
    }
}
