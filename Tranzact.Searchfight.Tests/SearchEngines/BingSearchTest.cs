using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Tranzact.Searchfight.Services.Interfaces;
using Tranzact.Searchfight.Services.SerachEngines;

namespace Tranzact.Searchfight.Tests.SearchEngines
{
    [TestClass]
    public class BingSearchTest
    {
        #region Attributes

        private ISearchEngine _searchEngine;

        #endregion

        #region Constructors

        public BingSearchTest()
        {
            _searchEngine = new BingSearch();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void GetResultsFromBing_Null_Query_ArgumentException()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(null));
        }

        [TestMethod]
        public void GetResultsFromBing_Empty_Query_ArgumentException()
        {
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchEngine.GetTotalResultsAsync(string.Empty));
        }

        [TestMethod]
        public async Task GetResultsFromBing_Success()
        {
            var result = await _searchEngine.GetTotalResultsAsync("java");
            Assert.IsNotNull(result);
        }

        #endregion
    }
}
