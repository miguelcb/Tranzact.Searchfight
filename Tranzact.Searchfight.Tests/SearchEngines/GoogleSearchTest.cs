using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Tranzact.Searchfight.Services.Interfaces;
using Tranzact.Searchfight.Services.SerachEngines;

namespace Tranzact.Searchfight.Tests.SearchEngines
{
    [TestClass]
    public class GoogleSearchTest
    {
        #region Attributes

        private ISearchEngine _searchEngine;

        #endregion

        #region Constructors

        public GoogleSearchTest()
        {
            _searchEngine = new GoogleSearch();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void GetResultsFromGoogle_Null_Query_ArgumentException()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(null));
        }

        [TestMethod]
        public void GetResultsFromGoogle_Empty_Query_ArgumentException()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(string.Empty));
        }

        [TestMethod]
        public async Task GetResultsFromGoogle_Success()
        {
            var result = await _searchEngine.GetTotalResultsAsync(".net");
            Assert.IsNotNull(result);
        }

        #endregion
    }
}
