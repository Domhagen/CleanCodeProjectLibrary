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
        public void ScraplistNoConditionOverOne()
        {
            ScraplistAPI scraplistAPI = SetUpTestData();
            var result = scraplistAPI.GetScraplist(1);
            Assert.IsTrue(Book.Equals(new Book(), result));
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
                        Condition = 1,
                    }
                });
            return scraplistAPI;
        }
    }
}
