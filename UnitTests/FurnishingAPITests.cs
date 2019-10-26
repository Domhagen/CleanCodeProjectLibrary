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
    public class FurnishingAPITests
    {
        [TestMethod]
        public void TestAddAisle()
        {
            Mock<IAisleManager> aisleManagerMock = SetupMock(null);
            bool successfull = AddAisleNumberOne(aisleManagerMock);
            Assert.IsTrue(successfull);
            aisleManagerMock.Verify(m =>
                m.AddAisle(It.Is<int>(i => i == 1)),
                    Times.Once());
        }
        [TestMethod]
        public void TestAddExistingAisle()
        {
            var aisleManagerMock = SetupMock(new Aisle());
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
                    AisleNumber = 4,
                    Shelf = new List<Shelf>()
                });

            var furnitureAPI = new FurnishingAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var successfull = furnitureAPI.RemoveAisle(4);
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

            var furnitureAPI = new FurnishingAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var successfull = furnitureAPI.RemoveAisle(4);
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

            var furnitureAPI = new FurnishingAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var successfull = furnitureAPI.RemoveAisle(4);
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

            var furnishingAPI = new FurnishingAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var successfull = furnishingAPI.AddShelf(1);
            Assert.IsTrue(successfull);
            shelfManagerMock.Verify(m =>
                m.AddShelf(It.Is<int>(i => i == 1)),
                    Times.Once());
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

            var furnishingAPI = new FurnishingAPI(aisleManagerMock.Object, shelfManagerMock.Object);
            var result = furnishingAPI.MoveShelf(1, 1);
            Assert.AreEqual(MoveShelfErrorCodes.Ok, result);
            shelfManagerMock.Verify(m =>
            m.MoveShelf(2, 2), Times.Once());
        }
        private static Mock<IAisleManager> SetupMock(Aisle aisle)
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
            var furnishingAPI = new FurnishingAPI(aisleManagerMock.Object, null);
            var successfull = furnishingAPI.AddAisle(1);
            return successfull;
        }
    }
}
