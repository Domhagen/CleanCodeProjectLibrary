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
    public class ScraplistAPITests
    {
        [TestMethod]
        public void GetScrapList()
        {
            ScraplistAPI scraplistAPI = SetUpTestData();
            var result = scraplistAPI.GetScraplist();
            Assert.AreEqual(ScraplistErrorCodes.Ok, result);
        }
        private static ScraplistAPI SetUpTestData()
        {
            var scraplistManagerMock = new Mock<IScraplistManager>();
            var bookManagerMock = new Mock<IBookManager>();
            var scraplistAPI = new ScraplistAPI(scraplistManagerMock.Object, bookManagerMock.Object);
            bookManagerMock.Setup(m =>
            m.GetAllBooks())
                .Returns(new List<Book> 
                { 
                    new Book
                    {
                        BookID = 1,
                        Condition = 1
                    },
                    new Book
                    {
                        BookID = 2,
                        Condition = 1
                    },
                    new Book
                    {
                        BookID = 3,
                        Condition = 2
                    }
                });
            return scraplistAPI;
        }
    }
}
