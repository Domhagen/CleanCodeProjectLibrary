using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using Library;

namespace UnitTests
{
    [TestClass]
    public class CustomerAPITests
    {
        [TestMethod]
        public void TestAddCustomer()
        {
            Mock<ICustomerManager> customerManagerMock = SetupMockCustomer(new Customer());

            var successfull = AddCustomerNumberOne(customerManagerMock);

            Assert.AreEqual(AddCustomerErrorCodes.Ok, successfull);
            customerManagerMock.Verify(m =>
                m.AddCustomer(It.Is<int>(i => i == 1), "9103273877"),
                Times.Once());
        }
        private static AddCustomerErrorCodes AddCustomerNumberOne(Mock<ICustomerManager> customerManagerMock)
        {
            var customerAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = customerAPI.AddCustomer(1, "9103273877");
            return successfull;
        }
        private static Mock<ICustomerManager> SetupMockCustomer(Customer customer)
        {
            var customerManagerMock = new Mock<ICustomerManager>();

            customerManagerMock.Setup(m =>
                    m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                .Returns(customer);

            customerManagerMock.Setup(m =>
                m.AddCustomer(It.IsAny<int>(),It.IsAny<string>()));
            return customerManagerMock;
        }
        [TestMethod]
        public void TestRemoveEmptyCustomer()
        {
            var customerManagerMock = new Mock<ICustomerManager>();

            customerManagerMock.Setup(m =>
            m.GetCustomerByCustomerNumber(It.IsAny<int>()))
                .Returns(new Customer
                {
                    CustomerNumber = 1,
                    Book = new List<Book>()
                });

            var libraryAPI = new CustomerAPI(customerManagerMock.Object);
            var successfull = libraryAPI.RemoveCustomer(4);
            Assert.AreEqual(RemoveCustomerErrorCodes.Ok, successfull);
            customerManagerMock.Verify(m =>
                m.RemoveCustomer(It.IsAny<int>()), Times.Once);
        }
    }
}
