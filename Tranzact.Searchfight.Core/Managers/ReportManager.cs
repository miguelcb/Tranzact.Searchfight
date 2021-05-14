using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tranzact.Searchfight.Core.Interfaces;
using Tranzact.Searchfight.Core.Models;

namespace Tranzact.Searchfight.Core.Managers
{
    public class ReportManager : IReportManager
    {
        #region Constants

        public const string TOTAL_WINNER_TITLE = "Total winner: ";

        #endregion

        #region Public Methods

        public IList<string> GetSearchResultsReport(IList<Search> searchData)
        {
            if (searchData == null || searchData.Count == 0)
                throw new ArgumentException("The specified parameter is invalid", nameof(searchData));

            return searchData.GroupBy(item => item.Term)
                .Select(group => $"{group.Key}: {string.Join(" ", group.Select(item => $"{item.SearchEngine}: {item.Results}"))}")
                .ToList();
        }

        public IList<string> GetWinnersReport(IEnumerable<Winner> engineWinners)
        {
            if (engineWinners == null || engineWinners.Count() == 0)
                throw new ArgumentException("The specified parameter is invalid", nameof(engineWinners));

            List<string> results = new List<string>();

            foreach (Winner winner in engineWinners)
            {
                StringBuilder winnerBuilder = new StringBuilder();
                winnerBuilder.Append(winner.Engine + " winner : ");
                winnerBuilder.Append(winner.Term);
                results.Add(winnerBuilder.ToString());
            }

            return results;
        }

        public string GetGrandWinnerReport(Winner grandWinner)
        {
            if (grandWinner == null)
                throw new ArgumentException("The specified parameter is invalid", nameof(grandWinner));

            StringBuilder grandWinnerBuilder = new StringBuilder();
            grandWinnerBuilder.Append(TOTAL_WINNER_TITLE);
            grandWinnerBuilder.Append(grandWinner.Engine);
            return grandWinnerBuilder.ToString();
        }

        #endregion
    }
}
