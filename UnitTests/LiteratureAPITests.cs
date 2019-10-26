using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using Library;
using IDataInterface;

namespace UnitTests
{
    [TestClass]
    public class LiteratureAPITests
    {
        [TestMethod]
        public void TestAddBook()
        {



            //var aisleManagerMock = new Mock<IAisleManager>();
            /*
            Mock<IAisleManager> aisleManagerMock = SetupMock(null);
            bool successfull = AddAisleNumberOne(aisleManagerMock);
            Assert.IsTrue(successfull);
            aisleManagerMock.Verify(m =>
                m.AddAisle(It.Is<int>(i => i == 1)),
                    Times.Once());
            */
        }
    }
}
