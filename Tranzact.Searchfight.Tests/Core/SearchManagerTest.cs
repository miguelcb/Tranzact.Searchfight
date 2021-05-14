using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tranzact.Searchfight.Core.Interfaces;
using Tranzact.Searchfight.Core.Managers;
using Tranzact.Searchfight.Core.Models;

namespace Tranzact.Searchfight.Tests.Core
{
    [TestClass]
    public class SearchManagerTest
    {
        #region Attributes

        private ISearchManager _searchManager;

        #endregion

        #region Constructors

        public SearchManagerTest()
        {
            _searchManager = new SearchManager();
        }

        #endregion

        #region Tests

        [TestMethod]
        public void GetSearchResult_Null_Terms_ArgumentException()
        {
            List<string> terms = null;
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchManager.GetSearchResults(terms));
        }

        [TestMethod]
        public void GetSearchResult_Empty_Terms_ArgumentException()
        {
            List<string> terms = new List<string>();
            Assert.ThrowsExceptionAsync<ArgumentException>(() => _searchManager.GetSearchResults(terms));
        }

        [TestMethod]
        public async Task GetSearchResults_Success()
        {
            List<string> terms = new List<string> { ".net", "phyton", "java script" };
            IList<Search> searchResults = await _searchManager.GetSearchResults(terms);
            Assert.IsNotNull(searchResults);
        }

        #endregion
    }
}
