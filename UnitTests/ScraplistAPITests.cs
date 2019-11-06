using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using IDataInterface;
using Library;

namespace UnitTests
{
    public class ScraplistAPITests
    {
        [TestMethod]
        public void ScraplistNoConditionOverOne()
        {
            Mock<IScraplistManager> scraplistManagerMock = SetupMock(null);
            var successfull = AddScraplistOfBooks(scraplistManagerMock);

        }

        private static AddScraplistOfBooks(Mock<IScraplistManager> scraplistManagerMock)
        {
            var scraplistAPI = new ScraplistAPI(scraplistManagerMock.Object, null);
            var successfull = scraplistAPI.GetScraplist(1);
            return successfull;
        }

        private Mock<IScraplistManager> SetupMock(object p)
        {
            var scraplistManagerMock = new Mock<IScraplistManager>();

            scraplistManagerMock.Setup(m =>
                m.GetScraplist());
            return scraplistManagerMock;
        }
    }
}
