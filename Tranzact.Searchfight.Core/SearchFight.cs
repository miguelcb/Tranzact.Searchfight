using System.Collections.Generic;
using System.Threading.Tasks;
using Tranzact.Searchfight.Core.Interfaces;
using Tranzact.Searchfight.Core.Managers;
using Tranzact.Searchfight.Core.Models;

namespace Tranzact.Searchfight.Core
{
    public static class SearchFight
    {
        #region Attributes

        public static List<string> Reports { get; private set; }

        #endregion

        #region Services

        static ISearchManager SearchManager;
        static IWinnerManager WinnerManager;
        static IReportManager ReportManager;

        #endregion

        #region Constructors

        static SearchFight()
        {
            // Initialize all our service dependencies
            SearchManager = new SearchManager();
            WinnerManager = new WinnerManager();
            ReportManager = new ReportManager();

            // Initialize our results attribute
            Reports = new List<string>();
        }

        #endregion

        #region Public Methods

        public static async Task ExecuteSearchFight(IList<string> terms)
        {
            IList<Search> searchData = await SearchManager.GetSearchResults(terms);
            IEnumerable<Winner> searchEngineWinners = WinnerManager.GetSearchEngineWinners(searchData);
            Winner grandWinner = WinnerManager.GetGrandWinner(searchData);

            Reports.AddRange(ReportManager.GetSearchResultsReport(searchData));
            Reports.AddRange(ReportManager.GetWinnersReport(searchEngineWinners));
            Reports.Add(ReportManager.GetGrandWinnerReport(grandWinner));
        }

        #endregion
    }
}
